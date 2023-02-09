using CleanAdArch.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAdArch.Infrastructure.Persistence.Configurations;

public class UserDatabaseConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);
        builder
            .Property(user => user.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder
            .Property(user => user.Name)
            .HasColumnName("Name")
            .HasColumnType("text");
        builder
            .Property(user => user.Admin)
            .HasColumnName("IsAdmin")
            .HasColumnType("boolean");
        builder
            .Property(user => user.SecondName)
            .HasColumnName("SecondName")
            .HasColumnType("text");
        builder
            .Property(user => user.Phone)
            .HasColumnName("Phone")
            .HasColumnType("text");
        builder
            .Property(user => user.Password)
            .HasColumnName("Password")
            .HasColumnType("text");
        builder
            .Property(user => user.Email)
            .HasColumnName("Email")
            .HasColumnType("text");
        builder
            .Property(user => user.HashedPassword)
            .HasColumnName("hashed_password")
            .HasColumnType("text");
        builder
            .HasMany(user => user.AdsList)
            .WithOne(ads => ads.User)
            .HasForeignKey(ads =>ads.UserId );
    }
}