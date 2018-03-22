using Microsoft.EntityFrameworkCore;
using StoreControl.Infrastructure.Database.Mappings;
using StoreControl.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StoreControl.Infrastructure.Database.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public ApplicationDbContext()
            : base(DesignTimeDbContextFactory.GetDbContextOptionsBuilder().Options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerAccountMappings());
            modelBuilder.ApplyConfiguration(new PurchaseMappings());
        }

        public static string GetConnection()
        {
            return $@"Data Source=(LocalDB)\mssqllocaldb;Database=StoreControl;Integrated Security=True;Connect Timeout=30";
        }
    }
}
