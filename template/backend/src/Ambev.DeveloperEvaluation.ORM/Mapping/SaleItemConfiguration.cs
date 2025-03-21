﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(si => si.ProductId)
            .IsRequired();

        builder.Property(si => si.ProductDescription)
            .IsRequired();

        builder.Property(si => si.Quantity)
            .IsRequired();

        builder.Property(si => si.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(si => si.DiscountPercentage)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(si => si.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(si => si.Cancelled)
            .IsRequired();
    }
}
