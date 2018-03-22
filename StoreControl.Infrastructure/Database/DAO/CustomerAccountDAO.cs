using Microsoft.EntityFrameworkCore;
using StoreControl.Infrastructure.Database.DAO.Base;
using StoreControl.Infrastructure.Database.DAO.Interfaces;
using StoreControl.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreControl.Infrastructure.Database.DAO
{
    public class CustomerAccountDAO : AppDaoBase<CustomerAccount>, ICustomerAccountDAO
    {
        protected override DbSet<CustomerAccount> DbSet => Context.CustomerAccounts;

        protected override string EntityName => "CustomerAccounts";
    }
}
