using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Persistence.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.LoanDate)
            .IsRequired();

        builder.Property(l => l.ExpectedReturnDate)
            .IsRequired();

        builder.Property(l => l.ReturnDate)
            .IsRequired(false);

        builder.HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.User)
            .WithMany(u => u.Loans)
            .HasForeignKey(l => l.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
