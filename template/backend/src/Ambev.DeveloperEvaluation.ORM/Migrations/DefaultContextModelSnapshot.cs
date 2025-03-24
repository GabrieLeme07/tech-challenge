﻿// <auto-generated />
using System;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.CartProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProducts");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int?>("MaxQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("MinQuantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Discounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("80944d57-50ea-492a-9378-27ee5673c946"),
                            IsActive = true,
                            MaxQuantity = 9,
                            MinQuantity = 4,
                            Percentage = 10m
                        },
                        new
                        {
                            Id = new Guid("637c75ab-12d4-4dab-9e7e-a32a81752f44"),
                            IsActive = true,
                            MaxQuantity = 20,
                            MinQuantity = 10,
                            Percentage = 20m
                        });
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("RatingId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("RatingId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000001"),
                            Category = "Eletronicos",
                            Image = "eletronico1.jpg",
                            Price = 1200.00m,
                            Quantity = 20,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000001"),
                            Title = "Smartphone Eletronico 1"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000002"),
                            Category = "Eletronicos",
                            Image = "eletronico2.jpg",
                            Price = 1300.00m,
                            Quantity = 18,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000002"),
                            Title = "Smartphone Eletronico 2"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000003"),
                            Category = "Eletronicos",
                            Image = "eletronico3.jpg",
                            Price = 2500.00m,
                            Quantity = 10,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000003"),
                            Title = "Smart TV Eletronico 3"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000004"),
                            Category = "Eletronicos",
                            Image = "eletronico4.jpg",
                            Price = 3000.00m,
                            Quantity = 8,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000004"),
                            Title = "Notebook Eletronico 4"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000005"),
                            Category = "Eletronicos",
                            Image = "eletronico5.jpg",
                            Price = 900.00m,
                            Quantity = 12,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000005"),
                            Title = "Tablet Eletronico 5"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000006"),
                            Category = "Eletronicos",
                            Image = "eletronico6.jpg",
                            Price = 1500.00m,
                            Quantity = 5,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000006"),
                            Title = "Câmera Eletronico 6"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000007"),
                            Category = "Eletronicos",
                            Image = "eletronico7.jpg",
                            Price = 200.00m,
                            Quantity = 25,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000007"),
                            Title = "Fone de Ouvido Eletronico 7"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000008"),
                            Category = "Eletronicos",
                            Image = "eletronico8.jpg",
                            Price = 350.00m,
                            Quantity = 30,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000008"),
                            Title = "Smartwatch Eletronico 8"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000009"),
                            Category = "Eletronicos",
                            Image = "eletronico9.jpg",
                            Price = 2800.00m,
                            Quantity = 7,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000009"),
                            Title = "Console Eletronico 9"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000a"),
                            Category = "Eletronicos",
                            Image = "eletronico10.jpg",
                            Price = 800.00m,
                            Quantity = 10,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000a"),
                            Title = "Monitor Eletronico 10"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000b"),
                            Category = "Bebidas",
                            Image = "bebida1.jpg",
                            Price = 5.00m,
                            Quantity = 50,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000b"),
                            Title = "Refrigerante Bebida 1"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000c"),
                            Category = "Bebidas",
                            Image = "bebida2.jpg",
                            Price = 5.50m,
                            Quantity = 60,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000c"),
                            Title = "Refrigerante Bebida 2"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000d"),
                            Category = "Bebidas",
                            Image = "bebida3.jpg",
                            Price = 8.00m,
                            Quantity = 40,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000d"),
                            Title = "Suco Bebida 3"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000e"),
                            Category = "Bebidas",
                            Image = "bebida4.jpg",
                            Price = 10.00m,
                            Quantity = 100,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000e"),
                            Title = "Cerveja Bebida 4"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000f"),
                            Category = "Bebidas",
                            Image = "bebida5.jpg",
                            Price = 50.00m,
                            Quantity = 30,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000f"),
                            Title = "Vinho Bebida 5"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000010"),
                            Category = "Bebidas",
                            Image = "bebida6.jpg",
                            Price = 2.00m,
                            Quantity = 80,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000010"),
                            Title = "Água Bebida 6"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000011"),
                            Category = "Bebidas",
                            Image = "bebida7.jpg",
                            Price = 7.50m,
                            Quantity = 35,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000011"),
                            Title = "Suco Bebida 7"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000012"),
                            Category = "Bebidas",
                            Image = "bebida8.jpg",
                            Price = 6.00m,
                            Quantity = 55,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000012"),
                            Title = "Refrigerante Bebida 8"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000013"),
                            Category = "Bebidas",
                            Image = "bebida9.jpg",
                            Price = 12.00m,
                            Quantity = 90,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000013"),
                            Title = "Cerveja Bebida 9"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000014"),
                            Category = "Bebidas",
                            Image = "bebida10.jpg",
                            Price = 2.50m,
                            Quantity = 70,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000014"),
                            Title = "Água Bebida 10"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000015"),
                            Category = "Decoração",
                            Image = "decoracao1.jpg",
                            Price = 45.00m,
                            Quantity = 15,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000015"),
                            Title = "Vaso Decoracao 1"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000016"),
                            Category = "Decoração",
                            Image = "decoracao2.jpg",
                            Price = 55.00m,
                            Quantity = 20,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000016"),
                            Title = "Vaso Decoracao 2"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000017"),
                            Category = "Decoração",
                            Image = "decoracao3.jpg",
                            Price = 120.00m,
                            Quantity = 10,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000017"),
                            Title = "Quadro Decoracao 3"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000018"),
                            Category = "Decoração",
                            Image = "decoracao4.jpg",
                            Price = 150.00m,
                            Quantity = 8,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000018"),
                            Title = "Relógio Decoracao 4"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000019"),
                            Category = "Decoração",
                            Image = "decoracao5.jpg",
                            Price = 80.00m,
                            Quantity = 12,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000019"),
                            Title = "Luminária Decoracao 5"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001a"),
                            Category = "Decoração",
                            Image = "decoracao6.jpg",
                            Price = 35.00m,
                            Quantity = 30,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001a"),
                            Title = "Almofada Decoracao 6"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001b"),
                            Category = "Decoração",
                            Image = "decoracao7.jpg",
                            Price = 200.00m,
                            Quantity = 5,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001b"),
                            Title = "Espelho Decoracao 7"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001c"),
                            Category = "Decoração",
                            Image = "decoracao8.jpg",
                            Price = 100.00m,
                            Quantity = 7,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001c"),
                            Title = "Cortina Decoracao 8"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001d"),
                            Category = "Decoração",
                            Image = "decoracao9.jpg",
                            Price = 750.00m,
                            Quantity = 3,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001d"),
                            Title = "Sofá Decoracao 9"
                        },
                        new
                        {
                            Id = new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001e"),
                            Category = "Decoração",
                            Image = "decoracao10.jpg",
                            Price = 350.00m,
                            Quantity = 4,
                            RatingId = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001e"),
                            Title = "Mesa Decoracao 10"
                        });
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<float>("Rate")
                        .HasPrecision(3, 2)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ratings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000001"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000002"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000003"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000004"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000005"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000006"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000007"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000008"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000009"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000a"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000b"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000c"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000d"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000e"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000f"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000010"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000011"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000012"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000013"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000014"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000015"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000016"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000017"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000018"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000019"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001a"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001b"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001c"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001d"),
                            Count = 10,
                            Rate = 5f
                        },
                        new
                        {
                            Id = new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001e"),
                            Count = 10,
                            Rate = 5f
                        });
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SaleNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SaleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("boolean");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("SaleItems", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Cart", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.CartProduct", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Cart", "Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Product", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.SaleItem", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Entities.Sale", null)
                        .WithMany("Items")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Entities.Sale", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
