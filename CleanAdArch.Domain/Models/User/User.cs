using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CleanAdArch.Domain.Models.User;

public class User
{
    public User(string name,bool admin, string secondName, string phone, string password, string email, string? hashedPassword = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Admin = admin;
        SecondName = secondName;
        Phone = phone;
        Password = password;
        Email = email;
        HashedPassword = hashedPassword;
    }
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool Admin { get; set; }
    public string? SecondName { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    
    [JsonIgnore] public string? HashedPassword { get; set; }

    [JsonIgnore] public virtual IEnumerable<Ads.Ads> AdsList { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<EndpointLog.EndpointLog> EndpointLogs { get; set; } = null!;
    
    [JsonIgnore] public virtual IEnumerable<RefreshToken.RefreshToken> RefreshTokens { get; set; } = null!;
    
    public void UpdatePassword(string hash)
    {
        HashedPassword = hash;
    }
}