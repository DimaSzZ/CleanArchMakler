using CleanAdArch.Domain.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAdArch.Infrastructure.Persistence.Configurations;

public class CategoryDatabaseConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(category => category.Id);
        builder
            .Property(category => category.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid");
        builder
            .Property(category => category.CategoryProduct)
            .HasColumnName("category_product")
            .HasColumnType("text");
        builder
            .HasMany(category => category.AdsList)
            .WithOne(ads => ads.Category)
            .HasForeignKey(ads => ads.CategoryId);
        builder
            .HasMany(category => category.SubCats)
            .WithOne(subcategory => subcategory.Category)
            .HasForeignKey(subcategory => subcategory.CategoryId);
    }
}