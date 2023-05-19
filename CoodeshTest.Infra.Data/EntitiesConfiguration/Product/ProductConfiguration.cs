using CoodeshTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.ProductId);
            builder.Property(p => p.Name);
            builder.Property(p => p.Price).HasPrecision(10,2);
            builder.HasOne<Creator>(t => t.Creator)
                   .WithMany(c => c.Products)
                   .HasForeignKey(t => t.CreatorId);
        }
    }
}
