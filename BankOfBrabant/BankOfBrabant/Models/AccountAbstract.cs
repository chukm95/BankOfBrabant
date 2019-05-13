using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class AccountAbstract
    {
        protected double Balance { get; set; }
        protected double Interest { get; set; }
        protected string AccountNumber { get; set; }
        public int PassNumber { get; set; }

        // add money function is called when a transaction adds money to an account.
        // withdraw money function is called when a transaction withdraws money from an account.
        public void AddMoney(double income) { }
        public void WithdrawMoney(double spent) { }
    }
}
