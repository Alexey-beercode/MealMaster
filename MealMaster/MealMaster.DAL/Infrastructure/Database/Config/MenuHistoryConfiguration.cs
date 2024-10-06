using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMaster.DAL.Infrastructure.Database.Config;

public class MenuHistoryConfiguration : IEntityTypeConfiguration<MenuHistory>
{
    public void Configure(EntityTypeBuilder<MenuHistory> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedDate).IsRequired();
    }
}