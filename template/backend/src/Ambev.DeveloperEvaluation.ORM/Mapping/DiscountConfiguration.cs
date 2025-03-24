using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discounts");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

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
            yield return new Discount { Id = new Guid("80944d57-50ea-492a-9378-27ee5673c946"), MinQuantity = 4, MaxQuantity = 9, Percentage = 10, IsActive = true };
            yield return new Discount { Id = new Guid("637c75ab-12d4-4dab-9e7e-a32a81752f44"), MinQuantity = 10, MaxQuantity = 20, Percentage = 20, IsActive = true };
        }
    }
}
