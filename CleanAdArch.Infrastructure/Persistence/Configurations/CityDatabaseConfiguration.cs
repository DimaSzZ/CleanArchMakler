using CleanAdArch.Domain.Models.City;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAdArch.Infrastructure.Persistence.Configurations;

public class CityDatabaseConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("cities");
        builder.HasKey(city => city.Id);
        builder
            .Property(city => city.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder
            .Property(city => city.CityName)
            .HasColumnName("city_name");
        builder
            .HasMany(city => city.AdsList)
            .WithOne(ads => ads.City)
            .HasForeignKey(t => t.CityId);
    }
}