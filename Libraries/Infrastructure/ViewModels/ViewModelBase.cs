using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ViewModels
{
    public abstract class ViewModelBase
    {
        public Guid? ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastDateTimeUpdate { get; set; }
    }
}
