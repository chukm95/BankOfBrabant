/*
 author: everyone
 date: 15-05-2019
 last edited: 16-05-2019
 changes:
 15-05-2019     created
 16-05-2019     added producttypes
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfBrabant.Models
{
    public class Products
    {
        public enum ProductTypes
        {
            PERSONAL,
            CREDIT
        }
        public int ID { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public double LoanLimit { get; set; }
        public double CurrentLoan { get; set; }
        public double InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public ProductTypes ProductType { get; set; }
    }
}
