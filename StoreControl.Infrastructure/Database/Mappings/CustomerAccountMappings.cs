using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreControl.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Infrastructure.Mapping;

namespace StoreControl.Infrastructure.Database.Mappings
{
    public class CustomerAccountMappings : EntityMap<CustomerAccount, Guid>
    {
        public override void Configure(EntityTypeBuilder<CustomerAccount> pBuilder)
        {
            base.Configure(pBuilder);
            pBuilder.ToTable("CustomerAccount");
            pBuilder.Property(pX => pX.Name).IsRequired();
            pBuilder.Property(pX => pX.CPF).IsRequired();
        }
    }
}
