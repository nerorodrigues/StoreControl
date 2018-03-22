using StoreControl.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Infrastructure;

namespace StoreControl.Infrastructure.Database.DAO.Interfaces
{
    public interface ICustomerAccountDAO: IDAO<CustomerAccount, Guid>
    {
    }
}
