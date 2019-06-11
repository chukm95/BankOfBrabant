using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankOfBrabant.Models;

namespace BankOfBrabant.Models
{
    public class BankOfBrabantContext : DbContext
    {
        public BankOfBrabantContext (DbContextOptions<BankOfBrabantContext> options)
            : base(options)
        {
        }

        public DbSet<BankOfBrabant.Models.Account> Account { get; set; }

        public DbSet<BankOfBrabant.Models.AccountHolder> AccountHolder { get; set; }

        public DbSet<BankOfBrabant.Models.Client> Client { get; set; }

        public DbSet<BankOfBrabant.Models.Employee> Employee { get; set; }

        public DbSet<BankOfBrabant.Models.Products> Products { get; set; }

        public DbSet<BankOfBrabant.Models.Transaction> Transaction { get; set; }
    }
}
