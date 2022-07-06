using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTestNetApp.Models;

namespace TechTestNetApp.Data
{
    public class AppDbContext : DbContext
    {
        /**
         * Data Sets
         */
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<SalesPerson> SalesPerson { get; set; }
        public DbSet<CarPurchase> CarPurchase { get; set; }
        /**
         * AppDbContext constructor.
         * @param options Context options
         */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
 
        
    }
}
