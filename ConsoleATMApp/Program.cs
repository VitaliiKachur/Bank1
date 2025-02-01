using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleATMApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ATMApp atmApp = new ATMApp();
            atmApp.Run();
        }
    }

    public class ATMApp
    {
        private List<Account> accounts;
        private AuthenticationService authService;

        public ATMApp()
        {
            accounts = new List<Account>
            {
                new Account("1234567890", "John Doe", 1000, "1000"),
                new Account("0987654321", "Alice Smith", 1500, "2000")
            };
            authService = new AuthenticationService(accounts);
        }

        public void Run()
        {
            Account authenticatedAccount = authService.AuthenticateUser();
            if (authenticatedAccount == null)
            {
                Console.WriteLine("Не вдалося увійти в систему.");
                return;
            }

            bool continueUsing = true;
            while (continueUsing)
            {
                DisplayMenu();
                continueUsing = ProcessUserChoice(authenticatedAccount);
            }

            Console.WriteLine("Дякуємо за використання сервісу!");
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("==== Головне меню ====");
            Console.WriteLine("1. Перевірка балансу");
            Console.WriteLine("2. Зняття коштів");
            Console.WriteLine("3. Переказ коштів");
            Console.WriteLine("4. Вихід");
            Console.Write("Оберіть опцію: ");
        }

        private bool ProcessUserChoice(Account authenticatedAccount)
        {
            var actions = new Dictionary<string, Action>
            {
                { "1", () => ShowBalance(authenticatedAccount) },
                { "2", () => WithdrawMoney(authenticatedAccount) },
                { "3", () => TransferMoney(authenticatedAccount) },
                { "4", () => { Console.WriteLine("Вихід з системи..."); } }
            };

            string choice = Console.ReadLine();
            if (actions.TryGetValue(choice, out Action action))
            {
                action.Invoke();
            }
            else
            {
                Console.WriteLine("Неправильний вибір.");
            }

            Console.WriteLine("\nНатисніть Enter для продовження...");
            Console.ReadLine();

            return choice != "4"; // Повертаємо `false`, якщо користувач вибрав вихід
        }

        private void ShowBalance(Account account)
        {
            Console.WriteLine($"Ваш поточний баланс: {account.GetBalance()}");
        }

        private void WithdrawMoney(Account account)
        {
            decimal amount = ReadAmountFromUser("Введіть суму для зняття: ");
            if (amount > 0 && account.Withdraw(amount))
            {
                Console.WriteLine($"Успішно знято {amount}. Новий баланс: {account.GetBalance()}");
            }
            else
            {
                Console.WriteLine("Недостатньо коштів або некоректна сума.");
            }
        }

        private void TransferMoney(Account sender)
        {
            Console.Write("Введіть номер картки отримувача: ");
            string recipientCard = Console.ReadLine();
            Account recipient = accounts.Find(acc => acc.CardNumber == recipientCard);

            if (recipient != null)
            {
                decimal amount = ReadAmountFromUser("Введіть суму для переказу: ");
                if (amount > 0 && sender.Transfer(recipient, amount))
                {
                    Console.WriteLine($"Успішно перераховано {amount} на рахунок {recipient.OwnerName}");
                }
                else
                {
                    Console.WriteLine("Перерахування не вдалося.");
                }
            }
            else
            {
                Console.WriteLine("Одержувач не знайдений.");
            }
        }

        private decimal ReadAmountFromUser(string message)
        {
            Console.Write(message);
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                return amount;
            }
            Console.WriteLine("Некоректний формат суми.");
            return -1;
        }
    }

    public class AuthenticationService
    {
        private List<Account> accounts;

        public AuthenticationService(List<Account> accounts)
        {
            this.accounts = accounts;
        }

        public Account AuthenticateUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Вхід в систему ===");

                (string cardNumber, string pin) = PromptForCredentials();
                Account account = FindAccount(cardNumber, pin);

                if (account != null)
                {
                    Console.Clear();
                    Console.WriteLine("Аутентифікація успішна!\n");
                    return account;
                }

                Console.WriteLine("Невдала спроба аутентифікації. Спробуйте ще раз!");
                Console.ReadLine();
            }
        }

        private (string cardNumber, string pin) PromptForCredentials()
        {
            Console.Write("Введіть номер картки: ");
            string cardNumber = Console.ReadLine();
            Console.Write("Введіть PIN: ");
            string pin = Console.ReadLine();
            return (cardNumber, pin);
        }

        private Account FindAccount(string cardNumber, string pin)
        {
            return accounts.FirstOrDefault(acc => acc.Authenticate(cardNumber, pin));
        }
    }

    public class Account
    {
        public string CardNumber { get; private set; }
        public string OwnerName { get; private set; }
        private decimal Balance;
        private string Pin;

        public Account(string cardNumber, string ownerName, decimal initialBalance, string pin)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            Balance = initialBalance;
            Pin = pin;
        }

        public bool Authenticate(string cardNumber, string pin)
        {
            return this.CardNumber == cardNumber && this.Pin == pin;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public bool Transfer(Account recipient, decimal amount)
        {
            if (Withdraw(amount))
            {
                recipient.Deposit(amount);
                return true;
            }
            return false;
        }
    }
}
