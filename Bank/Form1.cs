using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BankLibrary;

namespace Bank
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Account> _accounts;
        private Account _currentAccount;

        public Form1()
        {
            InitializeComponent();
            InitializeEvents();

            _accounts = new Dictionary<string, Account>
            {
                { "12345678", new Account("12345678", "Ivan Ivanov", 5000, "1234") },
                { "4141252547892585", new Account("4141252547892585", "Іван Франчук", 7000, "7777") },
                { "98765432", new Account("98765432", "Ольга Петренко", 8000, "1111") }
            };

            foreach (var account in _accounts.Values)
            {
                account.OnAuthentication += DisplayMessage;
                account.OnBalanceCheck += DisplayMessage;
                account.OnWithdraw += DisplayMessage;
                account.OnTransfer += DisplayMessage;
            }

            ToggleAuthenticatedControls(false);
            logoutButton.Visible = false;
        }

        private void InitializeEvents()
        {
            authenticateButton.Click += authenticateButton_Click;
            checkBalanceButton.Click += checkBalanceButton_Click;
            withdrawButton.Click += withdrawButton_Click;
            transferButton.Click += transferButton_Click;
            logoutButton.Click += logoutButton_Click;
        }

        private void ToggleAuthenticatedControls(bool isAuthenticated)
        {
            checkBalanceButton.Visible = isAuthenticated;
            withdrawButton.Visible = isAuthenticated;
            withdrawAmountTextBox.Visible = isAuthenticated;
            transferButton.Visible = isAuthenticated;
            recipientCardTextBox.Visible = isAuthenticated;
            transferAmountTextBox.Visible = isAuthenticated;
            logoutButton.Visible = isAuthenticated;
            label3.Visible = isAuthenticated;
            label4.Visible = isAuthenticated;
            label5.Visible = isAuthenticated;
            label6.Visible = isAuthenticated;
            label7.Visible = isAuthenticated;

            if (!isAuthenticated)
            {
                cardNumberTextBox.Clear();
                pinTextBox.Clear();
                withdrawAmountTextBox.Clear();
                transferAmountTextBox.Clear();
                recipientCardTextBox.Clear();
                messagesListBox.Items.Clear();
            }
        }

        private void DisplayMessage(string message)
        {
            messagesListBox.Items.Add(message);
        }

        private void ExecuteIfAuthenticated(Action action)
        {
            if (_currentAccount == null) return;
            action();
        }

        private void authenticateButton_Click(object sender, EventArgs e)
        {
            string cardNumber = cardNumberTextBox.Text;
            string pin = pinTextBox.Text;

            AuthenticateUser(cardNumber, pin);
        }

        private void AuthenticateUser(string cardNumber, string pin)
        {
            if (_accounts.TryGetValue(cardNumber, out var account) && account.Authenticate(cardNumber, pin))
            {
                _currentAccount = account;
                DisplayMessage("Вхід успішний.");
                ToggleAuthenticatedControls(true);
            }
            else
            {
                DisplayMessage("Невірний номер картки або PIN.");
                ToggleAuthenticatedControls(false);
            }
        }

        private void checkBalanceButton_Click(object sender, EventArgs e)
        {
            ExecuteIfAuthenticated(() => _currentAccount.CheckBalance());
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            ExecuteTransaction(withdrawAmountTextBox.Text, (amount) => _currentAccount.Withdraw(amount), "Зняття");
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            ExecuteTransaction(transferAmountTextBox.Text, (amount) =>
            {
                string recipientCard = recipientCardTextBox.Text;
                if (_accounts.TryGetValue(recipientCard, out var recipient))
                {
                    return _currentAccount.Transfer(recipient, amount);
                }
                DisplayMessage("Переказ не виконано. Перевірте наявність коштів або номер картки одержувача.");
                return false;
            }, "Переказ");
        }

        private void ExecuteTransaction(string amountText, Func<decimal, bool> operation, string operationName)
        {
            decimal amount = ParseAmount(amountText);
            if (amount <= 0) return;

            if (operation(amount))
            {
                DisplayMessage($"{operationName} {amount} успішно виконано.");
            }
            else
            {
                DisplayMessage($"Не вдалося виконати {operationName}. Перевірте наявність коштів або правильність введених даних.");
            }
        }

        private decimal ParseAmount(string input)
        {
            if (decimal.TryParse(input, out decimal amount) && amount > 0)
            {
                return amount;
            }
            DisplayMessage("Введіть коректну суму.");
            return -1;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            DisplayMessage("Ви вийшли з акаунту.");
            ToggleAuthenticatedControls(false);
            _currentAccount = null;
        }
    }
}
