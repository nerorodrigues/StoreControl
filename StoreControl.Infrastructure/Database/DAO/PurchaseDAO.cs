using Microsoft.EntityFrameworkCore;
using StoreControl.Infrastructure.Database.DAO.Base;
using StoreControl.Infrastructure.Database.DAO.Interfaces;
using StoreControl.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreControl.Infrastructure.Database.DAO
{
    public class PurchaseDAO : AppDaoBase<Purchase>, IPurchaseDAO
    {
        protected override DbSet<Purchase> DbSet => Context.Purchases;

        protected override string EntityName => "Purchases";

    }
}
