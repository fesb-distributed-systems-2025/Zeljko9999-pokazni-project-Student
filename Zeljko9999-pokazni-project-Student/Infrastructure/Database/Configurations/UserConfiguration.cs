using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.RoleId)
                .IsRequired();
        }
    }
}
