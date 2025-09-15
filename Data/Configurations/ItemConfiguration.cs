using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
           // Used the fluent API to set the properties 
           // in the Entityfreamework core
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.ItemName).IsRequired().HasMaxLength(100);
            
            builder.Property(x=>x.ItemDescription).HasMaxLength(200);

    }
    }
}
