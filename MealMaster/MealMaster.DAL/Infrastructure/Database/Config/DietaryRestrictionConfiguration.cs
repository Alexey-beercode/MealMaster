using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMaster.DAL.Infrastructure.Database.Config;

public class DietaryRestrictionConfiguration : IEntityTypeConfiguration<DietaryRestriction>
{
    public void Configure(EntityTypeBuilder<DietaryRestriction> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
    }
}