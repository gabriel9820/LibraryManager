using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.ISBN)
            .HasMaxLength(13);

        builder.Property(b => b.PublicationYear)
            .IsRequired();

        builder.Property(b => b.IsAvailable)
            .IsRequired();

        builder.HasMany(b => b.Loans)
            .WithOne(l => l.Book)
            .HasForeignKey(l => l.BookId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
