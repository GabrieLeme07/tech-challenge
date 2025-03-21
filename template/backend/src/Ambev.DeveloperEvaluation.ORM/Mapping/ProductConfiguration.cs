using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Image)
            .HasMaxLength(500);

        builder.Property(p => p.Quantity)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Discount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Total)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.RatingId)
            .IsRequired();
                
        builder.HasOne(p => p.Rating)
            .WithMany() 
            .HasForeignKey(p => p.RatingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
