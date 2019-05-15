using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankOfBrabant.Models
{
    public class BankOfBrabantContext : DbContext
    {
        public BankOfBrabantContext (DbContextOptions<BankOfBrabantContext> options)
            : base(options)
        {
        }

        public DbSet<BankOfBrabant.Models.RekeningOverzicht> RekeningOverzicht { get; set; }
    }
}
