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
    public enum Gender
    {
        FEMALE,
        MALE,
        OTHER
    }
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Insertion { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Gender gender { get; set; }
        public string KVKNumber { get; set; }
        public bool KVKPositive { get; set; }
        public bool Blacklisted { get; set; }
        public bool PassportCheck { get; set; }
    }
}
