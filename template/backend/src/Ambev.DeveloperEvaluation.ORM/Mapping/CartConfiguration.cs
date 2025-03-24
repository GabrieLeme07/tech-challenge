using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(u => u.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UserId)
            .IsRequired();

        builder.Property(c => c.Date)
            .IsRequired();
    }
}

