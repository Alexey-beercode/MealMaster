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
    [Migration("20241021184319_updated_user_table")]
    partial class updated_user_table
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
                            Id = new Guid("cc35c0d4-3a56-487f-9a49-b0b921feab8e"),
                            IsDeleted = false,
                            Name = "Итальянская"
                        },
                        new
                        {
                            Id = new Guid("3abc200b-6369-479f-bc4c-1c3eff6e45b0"),
                            IsDeleted = false,
                            Name = "Русская"
                        },
                        new
                        {
                            Id = new Guid("970ed01c-2c96-42c8-b5fd-5db347eb9e6c"),
                            IsDeleted = false,
                            Name = "Белорусская"
                        },
                        new
                        {
                            Id = new Guid("dcecab01-9625-4cb0-a28b-34878df6357e"),
                            IsDeleted = false,
                            Name = "Французская"
                        },
                        new
                        {
                            Id = new Guid("c19c4115-93c6-4d1e-90be-36592e37c65d"),
                            IsDeleted = false,
                            Name = "Китайская"
                        },
                        new
                        {
                            Id = new Guid("d32011db-8895-483a-a10b-62d547e352fe"),
                            IsDeleted = false,
                            Name = "Японская"
                        },
                        new
                        {
                            Id = new Guid("65ff2dca-4b95-4d43-be7a-d969f2e551cc"),
                            IsDeleted = false,
                            Name = "Мексиканская"
                        },
                        new
                        {
                            Id = new Guid("a6bba301-cbf8-4cef-a22d-a89e6935c7e8"),
                            IsDeleted = false,
                            Name = "Испанская"
                        },
                        new
                        {
                            Id = new Guid("1eceba06-b066-4d03-8312-fbb4b783cc63"),
                            IsDeleted = false,
                            Name = "Американская"
                        },
                        new
                        {
                            Id = new Guid("f4ddebb2-289c-4fa3-95b0-fbcbc839b591"),
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
                            Id = new Guid("f96c909a-aaa1-4d22-b2e6-8c08107bb841"),
                            IsDeleted = false,
                            Name = "Диабетическое"
                        },
                        new
                        {
                            Id = new Guid("975eb017-56df-4556-b2b9-006c8e0796f4"),
                            IsDeleted = false,
                            Name = "Вегетарианское"
                        },
                        new
                        {
                            Id = new Guid("06ced0e8-fec1-4625-8d3a-67a0012f1603"),
                            IsDeleted = false,
                            Name = "Безглютеновое"
                        },
                        new
                        {
                            Id = new Guid("134f94fe-4c85-4ccd-8dff-8d00e8fd9e1a"),
                            IsDeleted = false,
                            Name = "Кето"
                        },
                        new
                        {
                            Id = new Guid("93dedd30-5ceb-4b36-b6b8-0c97ad9404b1"),
                            IsDeleted = false,
                            Name = "Безлактозное"
                        },
                        new
                        {
                            Id = new Guid("1702957d-19f9-4180-9a00-0e2c5fd45515"),
                            IsDeleted = false,
                            Name = "Веганское"
                        },
                        new
                        {
                            Id = new Guid("e0b2c6fe-19d5-4e9d-b43b-cfe44d110158"),
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
                            Id = new Guid("3e888b86-6760-447f-a8ef-f3bbf1be6df0"),
                            IsDeleted = false,
                            Name = "Картофель"
                        },
                        new
                        {
                            Id = new Guid("54cd8eec-a46e-471b-b507-16930728121f"),
                            IsDeleted = false,
                            Name = "Курица"
                        },
                        new
                        {
                            Id = new Guid("0c6d2445-e6ea-4002-bdf3-8a8d5288a7c6"),
                            IsDeleted = false,
                            Name = "Говядина"
                        },
                        new
                        {
                            Id = new Guid("454aa185-2c00-4848-a140-fff89f7ccabb"),
                            IsDeleted = false,
                            Name = "Свинина"
                        },
                        new
                        {
                            Id = new Guid("7e1fced8-8edd-4764-86ad-9a350fe83b30"),
                            IsDeleted = false,
                            Name = "Морковь"
                        },
                        new
                        {
                            Id = new Guid("2e41c934-1d39-447a-9cec-71a72ed36bc7"),
                            IsDeleted = false,
                            Name = "Лук"
                        },
                        new
                        {
                            Id = new Guid("675490d5-fd3b-48a7-8757-cfac00aa1195"),
                            IsDeleted = false,
                            Name = "Чеснок"
                        },
                        new
                        {
                            Id = new Guid("a30d1934-21c4-4d6d-801a-83bdb7ee06e0"),
                            IsDeleted = false,
                            Name = "Яйца"
                        },
                        new
                        {
                            Id = new Guid("41d2081e-76e3-4519-904c-47cd63bb5dc2"),
                            IsDeleted = false,
                            Name = "Молоко"
                        },
                        new
                        {
                            Id = new Guid("d427dcac-95ee-414e-a9a8-377fe0721fa9"),
                            IsDeleted = false,
                            Name = "Мука"
                        },
                        new
                        {
                            Id = new Guid("15e70ada-6e93-425d-9d60-a453dfc889d2"),
                            IsDeleted = false,
                            Name = "Сыр"
                        },
                        new
                        {
                            Id = new Guid("e447f678-b612-45e8-91a8-a7eec27b34fe"),
                            IsDeleted = false,
                            Name = "Рис"
                        },
                        new
                        {
                            Id = new Guid("2190020a-eacc-471a-866e-5ea1682f5b34"),
                            IsDeleted = false,
                            Name = "Паста"
                        },
                        new
                        {
                            Id = new Guid("d2601e29-b656-4d97-b292-46a5f95e6e47"),
                            IsDeleted = false,
                            Name = "Помидоры"
                        },
                        new
                        {
                            Id = new Guid("954c3f8d-419e-41e1-a607-4d7f20a9f591"),
                            IsDeleted = false,
                            Name = "Огурцы"
                        },
                        new
                        {
                            Id = new Guid("2ba52c30-59cd-4a3a-892a-ca47b19f10b3"),
                            IsDeleted = false,
                            Name = "Перец"
                        },
                        new
                        {
                            Id = new Guid("6d843684-05d6-47bc-b44a-9ed0ee16a1b7"),
                            IsDeleted = false,
                            Name = "Сметана"
                        },
                        new
                        {
                            Id = new Guid("da011b1f-893a-49df-9402-84c6afb56f4f"),
                            IsDeleted = false,
                            Name = "Масло сливочное"
                        },
                        new
                        {
                            Id = new Guid("fe3b87f8-8319-42de-8983-68250505467c"),
                            IsDeleted = false,
                            Name = "Капуста"
                        },
                        new
                        {
                            Id = new Guid("fa3dc11b-2a9b-4d3c-af70-a0179a57962f"),
                            IsDeleted = false,
                            Name = "Гречка"
                        },
                        new
                        {
                            Id = new Guid("b352f597-3e95-404a-90bb-b5197a5f19dd"),
                            IsDeleted = false,
                            Name = "Бекон"
                        },
                        new
                        {
                            Id = new Guid("d4f2b27c-fcde-4d42-828c-e16b4095983c"),
                            IsDeleted = false,
                            Name = "Шпинат"
                        },
                        new
                        {
                            Id = new Guid("06386f49-9b8d-4051-9c52-09f046dc9fb6"),
                            IsDeleted = false,
                            Name = "Грибы"
                        },
                        new
                        {
                            Id = new Guid("8046b3d2-b28a-4972-af6b-13dee7ae1609"),
                            IsDeleted = false,
                            Name = "Брокколи"
                        },
                        new
                        {
                            Id = new Guid("dc4c6841-4a8e-47d2-ae27-74cea002c97a"),
                            IsDeleted = false,
                            Name = "Авокадо"
                        },
                        new
                        {
                            Id = new Guid("63cbc995-a396-422d-a144-6f0ad795ca93"),
                            IsDeleted = false,
                            Name = "Креветки"
                        },
                        new
                        {
                            Id = new Guid("802ba8ed-311a-4970-9034-a0043646c254"),
                            IsDeleted = false,
                            Name = "Тунец"
                        },
                        new
                        {
                            Id = new Guid("0d7fd82d-6474-428f-9c01-490028138a94"),
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

                    b.HasIndex("Email")
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
