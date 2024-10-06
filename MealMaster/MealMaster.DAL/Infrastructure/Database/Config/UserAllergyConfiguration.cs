using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMaster.DAL.Infrastructure.Database.Config;

public class UserAllergyConfiguration : IEntityTypeConfiguration<UserAllergy>
{
    public void Configure(EntityTypeBuilder<UserAllergy> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => new { e.UserId, e.AllergyId }).IsUnique();
    }
}