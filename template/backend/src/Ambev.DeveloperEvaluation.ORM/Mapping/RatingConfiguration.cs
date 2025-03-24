using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("Ratings");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

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
            yield return new Rating { Id = 1, Rate = 5, Count = 10 };
            yield return new Rating { Id = 2, Rate = 5, Count = 10 };
            yield return new Rating { Id = 3, Rate = 5, Count = 10 };
            yield return new Rating { Id = 4, Rate = 5, Count = 10 };
            yield return new Rating { Id = 5, Rate = 5, Count = 10 };
            yield return new Rating { Id = 6, Rate = 5, Count = 10 };
            yield return new Rating { Id = 7, Rate = 5, Count = 10 };
            yield return new Rating { Id = 8, Rate = 5, Count = 10 };
            yield return new Rating { Id = 9, Rate = 5, Count = 10 };
            yield return new Rating { Id = 10, Rate = 5, Count = 10 };

            // Categoria: Bebidas (10 itens)

            yield return new Rating { Id = 11, Rate = 5, Count = 10 };
            yield return new Rating { Id = 12, Rate = 5, Count = 10 };
            yield return new Rating { Id = 13, Rate = 5, Count = 10 };
            yield return new Rating { Id = 14, Rate = 5, Count = 10 };
            yield return new Rating { Id = 15, Rate = 5, Count = 10 };
            yield return new Rating { Id = 16, Rate = 5, Count = 10 };
            yield return new Rating { Id = 17, Rate = 5, Count = 10 };
            yield return new Rating { Id = 18, Rate = 5, Count = 10 };
            yield return new Rating { Id = 19, Rate = 5, Count = 10 };
            yield return new Rating { Id = 20, Rate = 5, Count = 10 };

            // Categoria: Decoração (10 itens)

            yield return new Rating { Id = 21, Rate = 5, Count = 10 };
            yield return new Rating { Id = 22, Rate = 5, Count = 10 };
            yield return new Rating { Id = 23, Rate = 5, Count = 10 };
            yield return new Rating { Id = 24, Rate = 5, Count = 10 };
            yield return new Rating { Id = 25, Rate = 5, Count = 10 };
            yield return new Rating { Id = 26, Rate = 5, Count = 10 };
            yield return new Rating { Id = 27, Rate = 5, Count = 10 };
            yield return new Rating { Id = 28, Rate = 5, Count = 10 };
            yield return new Rating { Id = 29, Rate = 5, Count = 10 };
            yield return new Rating { Id = 30, Rate = 5, Count = 10 };
        }
    }
}
