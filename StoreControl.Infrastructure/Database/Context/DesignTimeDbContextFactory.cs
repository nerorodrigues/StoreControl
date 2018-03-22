using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreControl.Infrastructure.Database.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return new ApplicationDbContext(GetDbContextOptionsBuilder().Options);
        }

        public static DbContextOptionsBuilder<ApplicationDbContext> GetDbContextOptionsBuilder()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(ApplicationDbContext.GetConnection());
            return builder;
        }
    }
}
