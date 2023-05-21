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
    public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.HasKey(t => t.CollaboratorId);
            builder.Property(p => p.Email);
            builder.Property(p => p.Password);
        }
    }
}
