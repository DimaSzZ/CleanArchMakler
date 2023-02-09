using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CleanAdArch.Domain.Models.City;

public class City
{
    public City(string cityName)
    {
        Id = Guid.NewGuid();
        CityName = cityName;
    }
    [Key]
    public Guid Id { get; set; }
    public string? CityName { get; set; }
    [JsonIgnore] public virtual IEnumerable<Ads.Ads>? AdsList { get; set; } = null!;

    
}