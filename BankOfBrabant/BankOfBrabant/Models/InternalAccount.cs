using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class InternalAccount:AccountAbstract
    {
        public InternalAccount(double balance, double interest, int accountNumber, int passNumber, int pinCode, string accountName)
        {
            Balance = balance;
            Interest = interest;
            AccountNumber = accountNumber;
            PassNumber = passNumber;
            PinCode = pinCode;
            AccountName = accountName;
        }

        public new void AddMoney(double addToSaving)
        {
            Balance += addToSaving;
        }

        public new void WithdrawMoney(double outGoing)
        {
            Balance -= outGoing;
        }
    }
}
