using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMaster.DAL.Infrastructure.Database.Config;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.RestrictionId).IsRequired();
        builder.Property(e => e.Calories).IsRequired();
        builder.Property(e => e.PreparationTime).IsRequired();
        builder.Property(e => e.CreatedDate).IsRequired();
        
        builder.HasOne<CuisineType>()
            .WithMany()
            .HasForeignKey(e => e.CuisineTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}