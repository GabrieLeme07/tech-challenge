using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

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

        builder.Property(p => p.RatingId)
            .IsRequired();

        builder.HasOne(p => p.Rating)
            .WithMany()
            .HasForeignKey(p => p.RatingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(Seed);
    }

    public IEnumerable<Product> Seed
    {
        get
        {
            // Categoria: Eletronicos
            yield return new Product { Id = 1, Title = "Smartphone Eletronico 1", Category = "Eletronicos", Image = "eletronico1.jpg", Quantity = 20, Price = 1200.00m, RatingId = 1 };
            yield return new Product { Id = 2, Title = "Smartphone Eletronico 2", Category = "Eletronicos", Image = "eletronico2.jpg", Quantity = 18, Price = 1300.00m, RatingId = 2 };
            yield return new Product { Id = 3, Title = "Smart TV Eletronico 3", Category = "Eletronicos", Image = "eletronico3.jpg", Quantity = 10, Price = 2500.00m, RatingId = 3 };
            yield return new Product { Id = 4, Title = "Notebook Eletronico 4", Category = "Eletronicos", Image = "eletronico4.jpg", Quantity = 8, Price = 3000.00m, RatingId = 4 };
            yield return new Product { Id = 5, Title = "Tablet Eletronico 5", Category = "Eletronicos", Image = "eletronico5.jpg", Quantity = 12, Price = 900.00m, RatingId = 5 };
            yield return new Product { Id = 6, Title = "Câmera Eletronico 6", Category = "Eletronicos", Image = "eletronico6.jpg", Quantity = 5, Price = 1500.00m, RatingId = 6 };
            yield return new Product { Id = 7, Title = "Fone de Ouvido Eletronico 7", Category = "Eletronicos", Image = "eletronico7.jpg", Quantity = 25, Price = 200.00m, RatingId = 7 };
            yield return new Product { Id = 8, Title = "Smartwatch Eletronico 8", Category = "Eletronicos", Image = "eletronico8.jpg", Quantity = 30, Price = 350.00m, RatingId = 8 };
            yield return new Product { Id = 9, Title = "Console Eletronico 9", Category = "Eletronicos", Image = "eletronico9.jpg", Quantity = 7, Price = 2800.00m, RatingId = 9 };
            yield return new Product { Id = 10, Title = "Monitor Eletronico 10", Category = "Eletronicos", Image = "eletronico10.jpg", Quantity = 10, Price = 800.00m, RatingId = 10 };

            // Categoria: Bebidas
            yield return new Product { Id = 11, Title = "Refrigerante Bebida 1", Category = "Bebidas", Image = "bebida1.jpg", Quantity = 50, Price = 5.00m, RatingId = 11 };
            yield return new Product { Id = 12, Title = "Refrigerante Bebida 2", Category = "Bebidas", Image = "bebida2.jpg", Quantity = 60, Price = 5.50m, RatingId = 12 };
            yield return new Product { Id = 13, Title = "Suco Bebida 3", Category = "Bebidas", Image = "bebida3.jpg", Quantity = 40, Price = 8.00m, RatingId = 13 };
            yield return new Product { Id = 14, Title = "Cerveja Bebida 4", Category = "Bebidas", Image = "bebida4.jpg", Quantity = 100, Price = 10.00m, RatingId = 14 };
            yield return new Product { Id = 15, Title = "Vinho Bebida 5", Category = "Bebidas", Image = "bebida5.jpg", Quantity = 30, Price = 50.00m, RatingId = 15 };
            yield return new Product { Id = 16, Title = "Água Bebida 6", Category = "Bebidas", Image = "bebida6.jpg", Quantity = 80, Price = 2.00m, RatingId = 16 };
            yield return new Product { Id = 17, Title = "Suco Bebida 7", Category = "Bebidas", Image = "bebida7.jpg", Quantity = 35, Price = 7.50m, RatingId = 17 };
            yield return new Product { Id = 18, Title = "Refrigerante Bebida 8", Category = "Bebidas", Image = "bebida8.jpg", Quantity = 55, Price = 6.00m, RatingId = 18 };
            yield return new Product { Id = 19, Title = "Cerveja Bebida 9", Category = "Bebidas", Image = "bebida9.jpg", Quantity = 90, Price = 12.00m, RatingId = 19 };
            yield return new Product { Id = 20, Title = "Água Bebida 10", Category = "Bebidas", Image = "bebida10.jpg", Quantity = 70, Price = 2.50m, RatingId = 20 };

            // Categoria: Decoração
            yield return new Product { Id = 21, Title = "Vaso Decoracao 2", Category = "Decoração", Image = "decoracao2.jpg", Quantity = 20, Price = 55.00m, RatingId = 22 };
            yield return new Product { Id = 22, Title = "Quadro Decoracao 3", Category = "Decoração", Image = "decoracao3.jpg", Quantity = 10, Price = 120.00m, RatingId = 23 };
            yield return new Product { Id = 23, Title = "Relógio Decoracao 4", Category = "Decoração", Image = "decoracao4.jpg", Quantity = 8, Price = 150.00m, RatingId = 24 };
            yield return new Product { Id = 24, Title = "Luminária Decoracao 5", Category = "Decoração", Image = "decoracao5.jpg", Quantity = 12, Price = 80.00m, RatingId = 25 };
            yield return new Product { Id = 25, Title = "Almofada Decoracao 6", Category = "Decoração", Image = "decoracao6.jpg", Quantity = 30, Price = 35.00m, RatingId = 26 };
            yield return new Product { Id = 26, Title = "Espelho Decoracao 7", Category = "Decoração", Image = "decoracao7.jpg", Quantity = 5, Price = 200.00m, RatingId = 27 };
            yield return new Product { Id = 27, Title = "Cortina Decoracao 8", Category = "Decoração", Image = "decoracao8.jpg", Quantity = 7, Price = 100.00m, RatingId = 28 };
            yield return new Product { Id = 28, Title = "Sofá Decoracao 9", Category = "Decoração", Image = "decoracao9.jpg", Quantity = 3, Price = 750.00m, RatingId = 29 };
            yield return new Product { Id = 29, Title = "Mesa Decoracao 10", Category = "Decoração", Image = "decoracao10.jpg", Quantity = 4, Price = 350.00m, RatingId = 30 };
            yield return new Product { Id = 30, Title = "Vaso Decoracao 1", Category = "Decoração", Image = "decoracao1.jpg", Quantity = 15, Price = 45.00m, RatingId = 21 };
        }
    }

}
