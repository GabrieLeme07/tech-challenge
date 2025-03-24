using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("Ratings");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(r => r.Rate)
            .IsRequired()
            .HasPrecision(3, 2);

        builder.Property(r => r.Count)
            .IsRequired();

        builder.HasData(Seed);
    }

    public IEnumerable<Rating> Seed
    {
        get
        {
            // Categoria: Eletronicos (10 itens)
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000001"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000002"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000003"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000004"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000005"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000006"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000007"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000008"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000009"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000a"), Rate = 5, Count = 10 };

            // Categoria: Bebidas (10 itens)
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000b"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000c"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000d"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000e"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000f"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000010"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000011"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000012"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000013"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000014"), Rate = 5, Count = 10 };

            // Categoria: Decoração (10 itens)
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000015"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000016"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000017"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000018"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000019"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001a"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001b"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001c"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001d"), Rate = 5, Count = 10 };
            yield return new Rating { Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001e"), Rate = 5, Count = 10 };
        }
    }
}
