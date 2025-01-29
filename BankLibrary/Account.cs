using System;

namespace BankLibrary
{
    public delegate void AccountActionHandler(string message);

    public class Account
    {
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; private set; }
        public string Pin { get; private set; } 

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
            if (this.CardNumber == cardNumber && this.Pin == pin)
            {
                OnAuthentication?.Invoke("Аутентифікація пройшла успішно");
                return true;
            }
            else
            {
                OnAuthentication?.Invoke("Аутентифікація не вдалася");
                return false;
            }
        }

        public decimal CheckBalance()
        {
            OnBalanceCheck?.Invoke($"Ваш поточний баланс: {Balance}");
            return Balance;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                OnWithdraw?.Invoke($"Зняття коштів успішне. Новий баланс: {Balance}");
                return true;
            }
            OnWithdraw?.Invoke("Недостатньо коштів для зняття.");
            return false;
        }

        public bool Transfer(Account recipient, decimal amount)
        {
            if (Withdraw(amount))
            {
                recipient.Balance += amount;
                OnTransfer?.Invoke($"Перерахування успішне. {amount} перераховано на рахунок {recipient.OwnerName}.");
                return true;
            }
            OnTransfer?.Invoke("Перерахування не вдалося.");
            return false;
        }
    }
}
