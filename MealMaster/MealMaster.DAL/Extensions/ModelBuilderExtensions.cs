using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedCuisineTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType { Id = Guid.NewGuid(), Name = "Итальянская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Русская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Белорусская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Французская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Китайская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Японская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Мексиканская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Испанская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Американская", IsDeleted = false },
                new CuisineType { Id = Guid.NewGuid(), Name = "Тайская", IsDeleted = false }
            );
        }

        public static void SeedDietaryRestrictions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DietaryRestriction>().HasData(
                new DietaryRestriction { Id = Guid.NewGuid(), Name = "Диабетическое", IsDeleted = false },
                new DietaryRestriction { Id = Guid.NewGuid(), Name = "Вегетарианское", IsDeleted = false },
                new DietaryRestriction { Id = Guid.NewGuid(), Name = "Безглютеновое", IsDeleted = false },
                new DietaryRestriction { Id = Guid.NewGuid(), Name = "Кето", IsDeleted = false },
                new DietaryRestriction { Id = Guid.NewGuid(), Name = "Безлактозное", IsDeleted = false },
                new DietaryRestriction { Id = Guid.NewGuid(), Name = "Веганское", IsDeleted = false },
                new DietaryRestriction { Id = Guid.NewGuid(), Name = "Палео", IsDeleted = false }
            );
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Картофель", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Курица", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Говядина", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Свинина", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Морковь", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Лук", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Чеснок", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Яйца", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Молоко", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Мука", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Сыр", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Рис", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Паста", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Помидоры", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Огурцы", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Перец", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Сметана", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Масло сливочное", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Капуста", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Гречка", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Бекон", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Шпинат", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Грибы", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Брокколи", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Авокадо", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Креветки", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Тунец", IsDeleted = false },
                new Product { Id = Guid.NewGuid(), Name = "Лосось", IsDeleted = false }
            );
        }

        public static void SeedAllData(this ModelBuilder builder)
        {
            builder.SeedProducts();
            builder.SeedCuisineTypes();
            builder.SeedDietaryRestrictions();
        }
    }
}