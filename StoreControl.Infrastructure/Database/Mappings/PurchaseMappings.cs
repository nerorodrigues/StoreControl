using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreControl.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Infrastructure.Mapping;

namespace StoreControl.Infrastructure.Database.Mappings
{
    public class PurchaseMappings : EntityMap<Purchase, Guid>
    {
        public override void Configure(EntityTypeBuilder<Purchase> pBuilder)
        {
            base.Configure(pBuilder);
            pBuilder.ToTable("Purchase");
            pBuilder.HasOne(pX=> pX.CustomerAccount)
                .WithMany()
                .HasForeignKey(pX=> pX.CustomerAccountID);
            pBuilder.Property(pX => pX.Amount).IsRequired();
            pBuilder.Property(pX => pX.Description).IsRequired();
        }
    }
}
