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
            // Categoria: Eletronicos (10 itens)
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000001"), Title = "Smartphone Eletronico 1", Category = "Eletronicos", Image = "eletronico1.jpg", Quantity = 20, Price = 1200.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000001") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000002"), Title = "Smartphone Eletronico 2", Category = "Eletronicos", Image = "eletronico2.jpg", Quantity = 18, Price = 1300.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000002") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000003"), Title = "Smart TV Eletronico 3", Category = "Eletronicos", Image = "eletronico3.jpg", Quantity = 10, Price = 2500.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000003") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000004"), Title = "Notebook Eletronico 4", Category = "Eletronicos", Image = "eletronico4.jpg", Quantity = 8, Price = 3000.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000004") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000005"), Title = "Tablet Eletronico 5", Category = "Eletronicos", Image = "eletronico5.jpg", Quantity = 12, Price = 900.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000005") }; yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000006"), Title = "Câmera Eletronico 6", Category = "Eletronicos", Image = "eletronico6.jpg", Quantity = 5, Price = 1500.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000006") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000007"), Title = "Fone de Ouvido Eletronico 7", Category = "Eletronicos", Image = "eletronico7.jpg", Quantity = 25, Price = 200.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000007") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000008"), Title = "Smartwatch Eletronico 8", Category = "Eletronicos", Image = "eletronico8.jpg", Quantity = 30, Price = 350.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000008") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000009"), Title = "Console Eletronico 9", Category = "Eletronicos", Image = "eletronico9.jpg", Quantity = 7, Price = 2800.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000009") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000a"), Title = "Monitor Eletronico 10", Category = "Eletronicos", Image = "eletronico10.jpg", Quantity = 10, Price = 800.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000a") };

            // Categoria: Bebidas (10 itens)
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000b"), Title = "Refrigerante Bebida 1", Category = "Bebidas", Image = "bebida1.jpg", Quantity = 50, Price = 5.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000b") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000c"), Title = "Refrigerante Bebida 2", Category = "Bebidas", Image = "bebida2.jpg", Quantity = 60, Price = 5.50m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000c") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000d"), Title = "Suco Bebida 3", Category = "Bebidas", Image = "bebida3.jpg", Quantity = 40, Price = 8.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000d") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000e"), Title = "Cerveja Bebida 4", Category = "Bebidas", Image = "bebida4.jpg", Quantity = 100, Price = 10.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000e") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000f"), Title = "Vinho Bebida 5", Category = "Bebidas", Image = "bebida5.jpg", Quantity = 30, Price = 50.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000f") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000010"), Title = "Água Bebida 6", Category = "Bebidas", Image = "bebida6.jpg", Quantity = 80, Price = 2.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000010") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000011"), Title = "Suco Bebida 7", Category = "Bebidas", Image = "bebida7.jpg", Quantity = 35, Price = 7.50m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000011") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000012"), Title = "Refrigerante Bebida 8", Category = "Bebidas", Image = "bebida8.jpg", Quantity = 55, Price = 6.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000012") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000013"), Title = "Cerveja Bebida 9", Category = "Bebidas", Image = "bebida9.jpg", Quantity = 90, Price = 12.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000013") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000014"), Title = "Água Bebida 10", Category = "Bebidas", Image = "bebida10.jpg", Quantity = 70, Price = 2.50m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000014") };

            // Categoria: Decoração (10 itens)
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000015"), Title = "Vaso Decoracao 1", Category = "Decoração", Image = "decoracao1.jpg", Quantity = 15, Price = 45.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000015") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000016"), Title = "Vaso Decoracao 2", Category = "Decoração", Image = "decoracao2.jpg", Quantity = 20, Price = 55.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000016") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000017"), Title = "Quadro Decoracao 3", Category = "Decoração", Image = "decoracao3.jpg", Quantity = 10, Price = 120.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000017") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000018"), Title = "Relógio Decoracao 4", Category = "Decoração", Image = "decoracao4.jpg", Quantity = 8, Price = 150.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000018") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000019"), Title = "Luminária Decoracao 5", Category = "Decoração", Image = "decoracao5.jpg", Quantity = 12, Price = 80.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000019") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001a"), Title = "Almofada Decoracao 6", Category = "Decoração", Image = "decoracao6.jpg", Quantity = 30, Price = 35.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001a") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001b"), Title = "Espelho Decoracao 7", Category = "Decoração", Image = "decoracao7.jpg", Quantity = 5, Price = 200.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001b") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001c"), Title = "Cortina Decoracao 8", Category = "Decoração", Image = "decoracao8.jpg", Quantity = 7, Price = 100.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001c") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001d"), Title = "Sofá Decoracao 9", Category = "Decoração", Image = "decoracao9.jpg", Quantity = 3, Price = 750.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001d") };
            yield return new Product { Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001e"), Title = "Mesa Decoracao 10", Category = "Decoração", Image = "decoracao10.jpg", Quantity = 4, Price = 350.00m, RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001e") };
        }
    }

}
