using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class DepositAccount:AccountAbstract
    {
        public TimeSpan timeLimit, time;
        public double CancellationFee;

        public DepositAccount(double balance, double interest, int accountNumber, int passNumber, int pinCode, string accountName)
        {
            Balance = balance;
            Interest = interest;
            AccountNumber = accountNumber;
            PassNumber = passNumber;
            PinCode = pinCode;
            AccountName = accountName;
        }

        public void FreezeMoney(double amount, DateTime endDate, DateTime startDate, int duration)
        {

        }
    }
}
