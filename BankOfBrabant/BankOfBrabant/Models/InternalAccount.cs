using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class InternalAccount:AccountAbstract
    {
        public InternalAccount(double balance, double interest, string accountNumber)
        {
            balance = this.Balance;
            interest = this.Interest;
            accountNumber = this.AccountNumber;
        }

        public new void AddMoney(double addToSaving)
        {
            Balance += addToSaving;
        }

        public new void WithdrawMoney(double outGoing)
        {
            Balance -= outGoing;
            //bla
        
        }
    }
}
