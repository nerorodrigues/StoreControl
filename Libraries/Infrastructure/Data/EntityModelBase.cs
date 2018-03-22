using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Utils.Infrastructure.Data
{
    public class EntityModelBase<T> where T: struct
    {
        public T ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastDateTimeUpdate { get; set; }
    }
}
