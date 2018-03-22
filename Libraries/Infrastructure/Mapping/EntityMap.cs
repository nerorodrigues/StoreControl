using Utils.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utils.Infrastructure.Mapping
{
    public abstract class EntityMap<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : EntityModelBase<TKey> where TKey : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> pBuilder)
        {
            pBuilder.HasKey(pX => pX.ID);
            pBuilder.Property(pX=> pX.ID).IsRequired().ValueGeneratedOnAdd();
            pBuilder.Property(pX => pX.CreationDate).IsRequired();
            pBuilder.Property(pX => pX.LastDateTimeUpdate).IsRequired(false);

            
        }
    }
}
