using CoodeshTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Infra.Data.EntitiesConfiguration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionId);
            builder.Property(p => p.DateTransaction);
            builder.Property(p => p.Type);
            builder.Property(p => p.Price).HasPrecision(10,2);
            builder.HasOne<Creator>(t => t.Creator)
                   .WithMany(c => c.Transactions)
                   .HasForeignKey(t => t.CreatorId);
            builder.HasOne<Product>(t => t.Product)
                   .WithMany(c => c.Transactions)
                   .HasForeignKey(t => t.ProductId);
            builder.HasOne<Affiliated>(t => t.Affiliated)
                   .WithMany(c => c.Transactions)
                   .HasForeignKey(t => t.AffiliatedId);
        }
    }
}
