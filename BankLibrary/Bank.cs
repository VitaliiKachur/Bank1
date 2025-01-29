using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankLibrary
{
    public class Bank
    {
        public string Name { get; set; }
        public List<AutomatedTellerMachine> ATMs { get; set; }

        public Bank(string name)
        {
            Name = name;
            ATMs = new List<AutomatedTellerMachine>();
        }

        public void AddATM(AutomatedTellerMachine atm)
        {
            ATMs.Add(atm);
        }
    }
}
