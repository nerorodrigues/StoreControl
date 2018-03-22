using StoreControl.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Infrastructure.Data;

namespace StoreControl.Infrastructure.Database.Models
{
    public class Purchase : EntityModelBase<Guid>
    {
        public String Description { get; set; }
        public Guid CustomerAccountID { get; set; }
        public float Amount { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}
