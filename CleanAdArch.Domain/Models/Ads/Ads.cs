using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace CleanAdArch.Domain.Models.Ads;

public class Ads
{

    public Ads(string heading,string? description, string? phone, double price,string? picture,
        Guid categoryId,Guid? subCategoryId ,Guid cityId,DateTime dateOfCreate,Guid userId)
    {
        Id = Guid.NewGuid();
        CityId = cityId;
        Heading = heading;
        Description = description;
        Phone = phone;
        Price = price;
        Picture = picture;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        DateOfCreate = dateOfCreate;
        UserId = userId;
    }
    
    [Key]
    public Guid Id { get; set; }
    public string? Heading { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public double Price { get; set; }
    public DateTime DateOfCreate { get; set; }
    public string? Picture { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ?SubCategoryId { get; set; }
    public Guid CityId { get; set; }
    public Guid UserId { get; set; }
    
    //for relationships
   [JsonIgnore] public City.City? City { get; set; }
   [JsonIgnore] public Category.Category? Category { get; set; }
   [JsonIgnore] public SubCategory.SubCategory? SubCategory { get; set; }
   [JsonIgnore] public User.User? User { get; set; }
   
   public AdsShort GetShort()
   {
       return new AdsShort(
           Id,
           UserId,
           Description,
           Heading,
           Picture,
           Phone,
           Price,
           DateOfCreate
       );
   }
}