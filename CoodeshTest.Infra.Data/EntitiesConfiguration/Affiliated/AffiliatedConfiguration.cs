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
    public class AffiliatedConfiguration : IEntityTypeConfiguration<Affiliated>
    {
        public void Configure(EntityTypeBuilder<Affiliated> builder)
        {
            builder.HasKey(t => t.AffiliatedId);
            builder.Property(p => p.Name);
        }
    }
}
