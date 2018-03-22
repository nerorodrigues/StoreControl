using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreControl.Shared.Model
{
    public class CustomerAccountModel : ViewModelBase
    {
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
