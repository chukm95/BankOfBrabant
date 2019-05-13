using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class AccountAbstract
    {
        public double Balance { get; set; }
        public double Interest { get; set; }
        public int AccountNumber { get; set; }
        public int PassNumber { get; set; }
        public string AccountName { get; set; }
        public int PinCode { get; set; }

        // add money function is called when a transaction adds money to an account.
        // withdraw money function is called when a transaction withdraws money from an account.
        public void AddMoney(double income) { }
        public void WithdrawMoney(double spent) { }
    }
}
