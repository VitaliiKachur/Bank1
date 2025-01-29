using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class AutomatedTellerMachine
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public decimal CashAvailable { get; private set; }

        public AutomatedTellerMachine(string id, string location, decimal initialCash)
        {
            Id = id;
            Location = location;
            CashAvailable = initialCash;
        }

        public void DispenseCash(decimal amount)
        {
            if (amount <= CashAvailable)
            {
                CashAvailable -= amount;
            }
        }
    }
}
