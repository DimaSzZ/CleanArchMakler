using CleanAdArch.Domain.Models.SubCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAdArch.Infrastructure.Persistence.Configurations;

public class SubCategoryDatabaseConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable("subcategories");
        builder.HasKey(subcategory => subcategory.Id);
        builder
            .Property(subcategory => subcategory.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder
            .Property(subcategory => subcategory.SubCategoryProduct)
            .HasColumnName("subcategory_product")
            .HasColumnType("text");
        builder
            .Property(subCategory => subCategory.CategoryId)
            .HasColumnName("categoryId")
            .HasColumnType("uuid");
        builder
            .HasOne(subcategory => subcategory.Category)
            .WithMany(category => category.SubCats)
            .HasForeignKey(category => category.CategoryId);
        builder
            .HasMany(subcategory => subcategory.AdsList)
            .WithOne(ads => ads.SubCategory)
            .HasForeignKey(ads => ads.SubCategoryId);
    }
}