using System;
using System.Collections.Generic;

namespace ConsoleATMApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ATMApp atmApp = new ATMApp();
            atmApp.Run();
        }
    }

    public class ATMApp
    {
        private List<Account> accounts;
        private AuthenticationService authService;
        private AccountService accountService;

        public ATMApp()
        {
            accounts = new List<Account>
            {
                new Account("1234567890", "John Doe", 1000, "1000"),
                new Account("0987654321", "Alice Smith", 1500, "2000")
            };

            authService = new AuthenticationService(accounts);
            accountService = new AccountService();
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
                Console.Clear();
                Console.WriteLine("==== Головне меню ====");
                Console.WriteLine("1. Перевірка балансу");
                Console.WriteLine("2. Зняття коштів");
                Console.WriteLine("3. Переказ коштів");
                Console.WriteLine("4. Вихід");
                Console.Write("Оберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        accountService.CheckBalance(authenticatedAccount);
                        break;

                    case "2":
                        decimal withdrawAmount = ReadAmountFromUser("Введіть суму для зняття: ");
                        if (withdrawAmount > 0)
                        {
                            accountService.Withdraw(authenticatedAccount, withdrawAmount);
                        }
                        break;

                    case "3":
                        Console.Write("Введіть номер картки отримувача: ");
                        string recipientCard = Console.ReadLine();
                        Account recipient = accounts.Find(acc => acc.CardNumber == recipientCard);

                        if (recipient != null)
                        {
                            decimal transferAmount = ReadAmountFromUser("Введіть суму для переказу: ");
                            if (transferAmount > 0)
                            {
                                accountService.Transfer(authenticatedAccount, recipient, transferAmount);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Одержувач не знайдений.");
                        }
                        break;

                    case "4":
                        continueUsing = false;
                        break;

                    default:
                        Console.WriteLine("Неправильний вибір.");
                        break;
                }

                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
            }

            Console.WriteLine("Дякуємо за використання сервісу!");
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
                Console.Write("Введіть номер картки: ");
                string cardNumber = Console.ReadLine();
                Console.Write("Введіть PIN: ");
                string pin = Console.ReadLine();

                foreach (var account in accounts)
                {
                    if (account.Authenticate(cardNumber, pin))
                    {
                        Console.Clear();
                        Console.WriteLine("Аутентифікація успішна!\n");
                        return account;
                    }
                }

                Console.WriteLine("Невдала спроба аутентифікації. Спробуйте ще раз!");
                Console.ReadLine();
            }
        }
    }

    public class AccountService
    {
        public void CheckBalance(Account account)
        {
            Console.WriteLine($"Ваш поточний баланс: {account.Balance}");
        }

        public void Withdraw(Account account, decimal amount)
        {
            if (amount > 0 && account.Withdraw(amount))
            {
                Console.WriteLine($"Успішно знято {amount}. Новий баланс: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Недостатньо коштів або некоректна сума.");
            }
        }

        public void Transfer(Account sender, Account recipient, decimal amount)
        {
            if (amount > 0 && sender.Transfer(recipient, amount))
            {
                Console.WriteLine($"Успішно перераховано {amount} на рахунок {recipient.OwnerName}");
            }
            else
            {
                Console.WriteLine("Перерахування не вдалося.");
            }
        }
    }

    public delegate void AccountActionHandler(string message);

    public class Account
    {
        public string CardNumber { get; private set; }
        public string OwnerName { get; private set; }
        public decimal Balance { get; private set; }
        private string Pin { get; set; }

        public event AccountActionHandler OnAuthentication;
        public event AccountActionHandler OnBalanceCheck;
        public event AccountActionHandler OnWithdraw;
        public event AccountActionHandler OnTransfer;

        public Account(string cardNumber, string ownerName, decimal initialBalance, string pin)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            Balance = initialBalance;
            Pin = pin;
        }

        public bool Authenticate(string cardNumber, string pin)
        {
            bool success = (this.CardNumber == cardNumber && this.Pin == pin);
            OnAuthentication?.Invoke(success ? "Аутентифікація успішна" : "Аутентифікація не вдалася");
            return success;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                OnWithdraw?.Invoke($"Зняття {amount} успішне. Новий баланс: {Balance}");
                return true;
            }
            OnWithdraw?.Invoke("Недостатньо коштів.");
            return false;
        }

        public bool Transfer(Account recipient, decimal amount)
        {
            if (Withdraw(amount))
            {
                recipient.Balance += amount;
                OnTransfer?.Invoke($"Перерахування {amount} на рахунок {recipient.OwnerName} успішне.");
                return true;
            }
            OnTransfer?.Invoke("Перерахування не вдалося.");
            return false;
        }
    }
}
