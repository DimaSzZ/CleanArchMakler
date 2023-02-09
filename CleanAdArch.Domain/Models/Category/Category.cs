using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CleanAdArch.Domain.Models.Category;

public class Category
{
    public Category(string categoryProduct)
    {
        Id = Guid.NewGuid();
        CategoryProduct = categoryProduct;
    }
    
    [Key]
    public Guid Id { get; set; }
    public string? CategoryProduct { get; set; }

    [JsonIgnore] public virtual IEnumerable<Ads.Ads>? AdsList { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<SubCategory.SubCategory>? SubCats { get; set; } = null!;
    
}