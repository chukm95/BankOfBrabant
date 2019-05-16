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
    public enum HolderType
    {
        HOLDER,
        COHOLDER,
        AUTHORIZED
    }
    public class AccountHolder
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public HolderType HolderType { get; set; }
    }
}
