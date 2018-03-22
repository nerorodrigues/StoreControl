using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreControl.Shared.Model
{
    public class PurchaseModel : ViewModelBase
    {
        public String Description { get; set; }
        public Guid CustomerAccountId { get; set; }
        public float Amount { get; set; }
        public CustomerAccountModel CustomerAccount { get; set; }
    }
}
