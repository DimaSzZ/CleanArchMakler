using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CleanAdArch.Domain.Models.SubCategory;

public class SubCategory
{
    public SubCategory(string subCategoryProduct,Guid categoryId)
    {
        Id = Guid.NewGuid();
        SubCategoryProduct = subCategoryProduct;
        CategoryId = categoryId;
    }
    [Key]
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string? SubCategoryProduct { get; set; }
    
    [JsonIgnore] public Category.Category? Category { get; set; }
    [JsonIgnore] public virtual IEnumerable<Ads.Ads>? AdsList { get; set; } = null!;

}