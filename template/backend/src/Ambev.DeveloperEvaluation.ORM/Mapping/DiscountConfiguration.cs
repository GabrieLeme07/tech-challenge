using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discounts");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.MinQuantity)
            .IsRequired();

        builder.Property(d => d.MaxQuantity);

        builder.Property(d => d.Percentage)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.HasData(Seed);
    }

    public IEnumerable<Discount> Seed
    {
        get
        {
            yield return new Discount { Id = 1, MinQuantity = 4, MaxQuantity = 9, Percentage = 10, IsActive = true };
            yield return new Discount { Id = 2, MinQuantity = 10, MaxQuantity = 20, Percentage = 20, IsActive = true };
        }
    }
}
