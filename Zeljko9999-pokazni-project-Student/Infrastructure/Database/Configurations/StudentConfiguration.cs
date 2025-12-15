using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);
            builder.Property(e => e.Id).IsRequired();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Surname)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.EmailAddress)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.Age)
                   .IsRequired(false);

            builder.Property(s => s.BirthDate)
                   .IsRequired(false);

            builder.HasIndex(s => s.EmailAddress)
                   .IsUnique();

            builder.HasOne(e => e.ProgramType)
                   .WithMany()
                   .HasForeignKey(e => e.ProgramTypeId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
