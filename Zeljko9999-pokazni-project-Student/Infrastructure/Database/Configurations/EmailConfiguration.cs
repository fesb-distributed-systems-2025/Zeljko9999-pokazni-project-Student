using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Emails");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.Subject)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Message)
                   .HasMaxLength(2000);

            builder.HasOne(e => e.Sender)
                   .WithMany(s => s.SentEmails)
                   .HasForeignKey(e => e.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Receiver)
                   .WithMany(s => s.ReceivedEmails)
                   .HasForeignKey(e => e.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
