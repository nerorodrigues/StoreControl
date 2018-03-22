using StoreControl.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Infrastructure.Data;

namespace StoreControl.Infrastructure.Database.Models
{
    public class CustomerAccount : EntityModelBase<Guid>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public Status Status { get; set; }
    }
}
