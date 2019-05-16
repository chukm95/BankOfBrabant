/*
 author: everyone
 date: 15-05-2019
 last edited: 16-05-2019
 changes:
 15-05-2019     created
 16-05-2019     added creditlimit
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public enum AccountTypes
    {
        PAYMENT,
        SAVING,
        DEPOSIT,
        INTERN
    }
    public class Account
    {
     
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [ReadOnly(true)]
        public String Number { get; set; }
        public AccountTypes AccountType { get; set; }
        public decimal Balance { get; set; }
        public float InterestRate { get; set; }
        public String AccountName { get; set; }
        public int PassNumber { get; set; }
        public int Pincode { get; set; }
        public int CreditLimit { get; set; }
    }
}
