﻿// <auto-generated />
using System;
using MealMaster.DAL.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealMaster.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241030190244_updated_user_config")]
    partial class updated_user_config
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MealMaster.Domain.Entities.CuisineType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("CuisineTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("08e23047-b751-40de-92e8-43d574eb8335"),
                            IsDeleted = false,
                            Name = "Итальянская"
                        },
                        new
                        {
                            Id = new Guid("dab599a1-0aff-4117-ad5e-cb25327c3e68"),
                            IsDeleted = false,
                            Name = "Русская"
                        },
                        new
                        {
                            Id = new Guid("5d72c2f1-a3f7-430d-9c2f-11ca66ee9d81"),
                            IsDeleted = false,
                            Name = "Белорусская"
                        },
                        new
                        {
                            Id = new Guid("9e42a430-ced2-45fe-bf23-6f92c5ada21d"),
                            IsDeleted = false,
                            Name = "Французская"
                        },
                        new
                        {
                            Id = new Guid("f02e2d3c-7735-48ab-90fe-fe338ec44d57"),
                            IsDeleted = false,
                            Name = "Китайская"
                        },
                        new
                        {
                            Id = new Guid("a3cc00db-102d-43cd-8cf8-633300951928"),
                            IsDeleted = false,
                            Name = "Японская"
                        },
                        new
                        {
                            Id = new Guid("089154d5-79d5-4536-9312-7f8fcdd8fda3"),
                            IsDeleted = false,
                            Name = "Мексиканская"
                        },
                        new
                        {
                            Id = new Guid("0f213aec-2e11-4752-a213-57ea2cb3b8e7"),
                            IsDeleted = false,
                            Name = "Испанская"
                        },
                        new
                        {
                            Id = new Guid("4fc0e6b8-d08b-4547-ad3a-eb38a63d3044"),
                            IsDeleted = false,
                            Name = "Американская"
                        },
                        new
                        {
                            Id = new Guid("6cf79fba-9217-4d13-9aa2-51aedd03104b"),
                            IsDeleted = false,
                            Name = "Тайская"
                        });
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.DietaryRestriction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("DietaryRestrictions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3c47249-fd0b-47a4-b796-8ce55fa2c102"),
                            IsDeleted = false,
                            Name = "Диабетическое"
                        },
                        new
                        {
                            Id = new Guid("59d9818e-bb66-48c3-a12f-f1bcf474f399"),
                            IsDeleted = false,
                            Name = "Вегетарианское"
                        },
                        new
                        {
                            Id = new Guid("4747f411-5ae9-4622-ad5e-c4239b3deada"),
                            IsDeleted = false,
                            Name = "Безглютеновое"
                        },
                        new
                        {
                            Id = new Guid("472941d0-e498-445a-a162-b9bb8c534725"),
                            IsDeleted = false,
                            Name = "Кето"
                        },
                        new
                        {
                            Id = new Guid("92c5f01f-80ab-45f1-a74d-7f8d9d34d44f"),
                            IsDeleted = false,
                            Name = "Безлактозное"
                        },
                        new
                        {
                            Id = new Guid("ce7aa8cb-1fa6-40e0-a083-296b9fe007db"),
                            IsDeleted = false,
                            Name = "Веганское"
                        },
                        new
                        {
                            Id = new Guid("90a5655f-306d-47ca-9b41-61397587ff0a"),
                            IsDeleted = false,
                            Name = "Палео"
                        });
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MealCount")
                        .HasColumnType("integer");

                    b.Property<int>("TotalCalories")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.MenuHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("MenuHistories");
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uuid");

                    b.Property<int>("PortionSize")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MenuId", "RecipeId")
                        .IsUnique();

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("743c96c8-7dbc-4d4b-88e1-3884a0e65988"),
                            IsDeleted = false,
                            Name = "Картофель"
                        },
                        new
                        {
                            Id = new Guid("d12b2b22-b0c2-4e63-b38e-07b43ec9b073"),
                            IsDeleted = false,
                            Name = "Курица"
                        },
                        new
                        {
                            Id = new Guid("c30c5b64-7414-46ab-bea9-ba9061b894d0"),
                            IsDeleted = false,
                            Name = "Говядина"
                        },
                        new
                        {
                            Id = new Guid("68528ea8-4109-4e2c-9596-e60f469d8a5c"),
                            IsDeleted = false,
                            Name = "Свинина"
                        },
                        new
                        {
                            Id = new Guid("da9437b3-9c13-47f6-8934-0f0440ca5719"),
                            IsDeleted = false,
                            Name = "Морковь"
                        },
                        new
                        {
                            Id = new Guid("19abef49-08f9-46ff-8d5c-fd50863c3f05"),
                            IsDeleted = false,
                            Name = "Лук"
                        },
                        new
                        {
                            Id = new Guid("9fdcf65b-87bc-4ce1-8ded-2e366cc6e030"),
                            IsDeleted = false,
                            Name = "Чеснок"
                        },
                        new
                        {
                            Id = new Guid("b8c12027-695a-4ec7-8fa8-9cda3bf776cf"),
                            IsDeleted = false,
                            Name = "Яйца"
                        },
                        new
                        {
                            Id = new Guid("f8107393-2d49-4aa9-ba30-edf3008af4d9"),
                            IsDeleted = false,
                            Name = "Молоко"
                        },
                        new
                        {
                            Id = new Guid("d4eb6d82-7eb1-4c5c-a108-b83f86954224"),
                            IsDeleted = false,
                            Name = "Мука"
                        },
                        new
                        {
                            Id = new Guid("8fd2abc2-7b95-4d0e-a58b-a2079a97904e"),
                            IsDeleted = false,
                            Name = "Сыр"
                        },
                        new
                        {
                            Id = new Guid("dd9eac3c-3d1a-44a2-8c9c-83486d3071e0"),
                            IsDeleted = false,
                            Name = "Рис"
                        },
                        new
                        {
                            Id = new Guid("16d6e488-65dd-43b5-9ae3-f2cea6e1f3b6"),
                            IsDeleted = false,
                            Name = "Паста"
                        },
                        new
                        {
                            Id = new Guid("97b76ee4-cb35-45ad-8880-3f34ecd65f64"),
                            IsDeleted = false,
                            Name = "Помидоры"
                        },
                        new
                        {
                            Id = new Guid("d0ffb849-2669-4d3e-ae7a-c45b10521719"),
                            IsDeleted = false,
                            Name = "Огурцы"
                        },
                        new
                        {
                            Id = new Guid("04393948-97a2-4d50-bf33-acf261225295"),
                            IsDeleted = false,
                            Name = "Перец"
                        },
                        new
                        {
                            Id = new Guid("96d5ddea-8f27-4d26-8758-eaa5f4f5889f"),
                            IsDeleted = false,
                            Name = "Сметана"
                        },
                        new
                        {
                            Id = new Guid("5b484f75-e66a-4213-ab0d-2c0fe42b74b7"),
                            IsDeleted = false,
                            Name = "Масло сливочное"
                        },
                        new
                        {
                            Id = new Guid("13330f16-1ad5-4a11-b4af-d650e4be4a68"),
                            IsDeleted = false,
                            Name = "Капуста"
                        },
                        new
                        {
                            Id = new Guid("46ef97e0-4549-408d-8f6a-477827a7568e"),
                            IsDeleted = false,
                            Name = "Гречка"
                        },
                        new
                        {
                            Id = new Guid("2e68a284-e64b-46a6-bfe1-7edccf5db6df"),
                            IsDeleted = false,
                            Name = "Бекон"
                        },
                        new
                        {
                            Id = new Guid("32061e4e-a2c1-4f95-b726-8b92b97f2fb4"),
                            IsDeleted = false,
                            Name = "Шпинат"
                        },
                        new
                        {
                            Id = new Guid("58fe7fe8-9ca7-449f-adff-5be021723955"),
                            IsDeleted = false,
                            Name = "Грибы"
                        },
                        new
                        {
                            Id = new Guid("8a774d16-dfae-4d49-a4d2-e6eb1de451db"),
                            IsDeleted = false,
                            Name = "Брокколи"
                        },
                        new
                        {
                            Id = new Guid("c8bf97ae-0a29-4eba-a0d1-84b5d59d13e1"),
                            IsDeleted = false,
                            Name = "Авокадо"
                        },
                        new
                        {
                            Id = new Guid("8a3927e8-0a11-472e-96f4-5aed54467bbf"),
                            IsDeleted = false,
                            Name = "Креветки"
                        },
                        new
                        {
                            Id = new Guid("6abba270-f0bd-4220-9922-c485c9b013d4"),
                            IsDeleted = false,
                            Name = "Тунец"
                        },
                        new
                        {
                            Id = new Guid("e64c4218-3e28-4b0a-a64e-09e935785aff"),
                            IsDeleted = false,
                            Name = "Лосось"
                        });
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Calories")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CuisineTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("PreparationTime")
                        .HasColumnType("integer");

                    b.Property<Guid>("RestrictionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CuisineTypeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.RecipeProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("RecipeProducts");
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.UserRestriction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RestrictionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "RestrictionId")
                        .IsUnique();

                    b.ToTable("UserRestrictions");
                });

            modelBuilder.Entity("MealMaster.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("MealMaster.Domain.Entities.CuisineType", null)
                        .WithMany()
                        .HasForeignKey("CuisineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}