using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Database.Configurations
{
    public class ProgramTypeConfiguration : IEntityTypeConfiguration<ProgramType>
    {
        public void Configure(EntityTypeBuilder<ProgramType> builder)
        {
            builder.ToTable("ProgramTypes");

            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.Title)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
