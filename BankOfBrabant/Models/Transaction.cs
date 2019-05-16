/*
 author: everyone
 date: 15-05-2019
 last edited: 15-05-2019
 changes:
 15-05-2019     created
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int SenderAccountId { get; set; }
        public Account Account { get; set; }
        public int ReceiverAccountId { get; set; }
        public Account ReceiverAccount { get; set; }
        public double Euro { get; set; }
        public DateTime Date { get; set; }
        public bool Verified { get; set; }
    }
}
