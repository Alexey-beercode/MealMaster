using MealMaster.DAL.Infrastructure.Database.Config;
using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }
    public DbSet<UserRestriction> UserRestrictions { get; set; }
    public DbSet<Allergy> Allergies { get; set; }
    public DbSet<UserAllergy> UserAllergies { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<MenuHistory> MenuHistories { get; set; }
    public DbSet<CuisineType> CuisineTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DietaryRestrictionConfiguration());
        modelBuilder.ApplyConfiguration(new UserRestrictionConfiguration());
        modelBuilder.ApplyConfiguration(new AllergyConfiguration());
        modelBuilder.ApplyConfiguration(new UserAllergyConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        modelBuilder.ApplyConfiguration(new MenuConfiguration());
        modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
        modelBuilder.ApplyConfiguration(new MenuHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new CuisineTypeConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}