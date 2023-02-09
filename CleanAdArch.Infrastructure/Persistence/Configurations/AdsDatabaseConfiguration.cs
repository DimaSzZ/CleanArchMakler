using CleanAdArch.Domain.Models.Ads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAdArch.Infrastructure.Persistence.Configurations;

public class AdsDatabaseConfiguration : IEntityTypeConfiguration<Ads>
{
    public void Configure(EntityTypeBuilder<Ads> builder)
    {
        builder.ToTable("Ads");
        builder.HasKey(ads => ads.Id);
        builder
            .Property(ads => ads.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder
            .Property(ads => ads.Heading)
            .HasColumnName("heading")
            .HasColumnType("text");
        builder
            .Property(ads => ads.Description)
            .HasColumnName("description")
            .HasColumnType("text");
        builder
            .Property(ads => ads.Phone)
            .HasColumnName("phone")
            .HasColumnType("text");
        builder
            .Property(ads => ads.DateOfCreate)
            .HasColumnName("date_of_create")
            .HasColumnType("date");
        builder
            .Property(ads => ads.Picture)
            .HasColumnName("picture")
            .HasColumnType("text");
        builder
            .Property(ads => ads.CategoryId)
            .HasColumnName("category_id")
            .HasColumnType("uuid");
        builder
            .Property(ads => ads.SubCategoryId)
            .HasColumnName("sub_category_id")
            .HasColumnType("uuid");
        builder
            .Property(ads => ads.CityId)
            .HasColumnName("city_id")
            .HasColumnType("uuid");
        builder
            .Property(ads => ads.UserId)
            .HasColumnName("user_id")
            .HasColumnType("uuid");
        builder
            .HasOne(ads => ads.City)
            .WithMany(city => city.AdsList)
            .HasForeignKey(city => city.CityId);
        builder
            .HasOne(ads => ads.Category)
            .WithMany(category => category.AdsList)
            .HasForeignKey(category => category.CategoryId);
        builder
            .HasOne(ads => ads.SubCategory)
            .WithMany(subcategory => subcategory.AdsList)
            .HasForeignKey(category => category.SubCategoryId);
        builder
            .HasOne(ads => ads.User)
            .WithMany(user => user.AdsList)
            .HasForeignKey(category => category.UserId);
    }
}