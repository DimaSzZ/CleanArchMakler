﻿// <auto-generated />
using System;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanAdArch.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(SupabaseDbContext))]
    partial class SupabaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanAdArch.Domain.Models.Ads.Ads", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid")
                        .HasColumnName("city_id");

                    b.Property<DateTime>("DateOfCreate")
                        .HasColumnType("date")
                        .HasColumnName("date_of_create");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Heading")
                        .HasColumnType("text")
                        .HasColumnName("heading");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Picture")
                        .HasColumnType("text")
                        .HasColumnName("picture");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("sub_category_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Ads", (string)null);
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.Category.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("CategoryProduct")
                        .HasColumnType("text")
                        .HasColumnName("category_product");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.City.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CityName")
                        .HasColumnType("text")
                        .HasColumnName("city_name");

                    b.HasKey("Id");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.EndpointLog.EndpointLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AccessToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Anonymous")
                        .HasColumnName("access_token");

                    b.Property<TimeSpan>("ElapsedTime")
                        .HasColumnType("interval")
                        .HasColumnName("elapsed_time");

                    b.Property<string>("ErrorDescription")
                        .HasColumnType("text")
                        .HasColumnName("error_description");

                    b.Property<string>("ExceptionName")
                        .HasColumnType("text")
                        .HasColumnName("exception_name");

                    b.Property<string>("HandlerName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("handler_name");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<object>("Request")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("request");

                    b.Property<DateTime>("RespondedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("responded_at");

                    b.Property<object>("Response")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("response");

                    b.Property<int>("StatusCode")
                        .HasColumnType("integer")
                        .HasColumnName("status_code");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("endpoints_logs", (string)null);
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.RefreshToken.RefreshToken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("expires_at");

                    b.Property<bool>("Revoked")
                        .HasColumnType("boolean")
                        .HasColumnName("revoked");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("refresh_tokens", (string)null);
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.SubCategory.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("categoryId");

                    b.Property<string>("SubCategoryProduct")
                        .HasColumnType("text")
                        .HasColumnName("subcategory_product");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("subcategories", (string)null);
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Admin")
                        .HasColumnType("boolean")
                        .HasColumnName("IsAdmin");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("text")
                        .HasColumnName("hashed_password");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("Password");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("Phone");

                    b.Property<string>("SecondName")
                        .HasColumnType("text")
                        .HasColumnName("SecondName");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.Ads.Ads", b =>
                {
                    b.HasOne("CleanAdArch.Domain.Models.Category.Category", "Category")
                        .WithMany("AdsList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanAdArch.Domain.Models.City.City", "City")
                        .WithMany("AdsList")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanAdArch.Domain.Models.SubCategory.SubCategory", "SubCategory")
                        .WithMany("AdsList")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanAdArch.Domain.Models.User.User", "User")
                        .WithMany("AdsList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");

                    b.Navigation("SubCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.EndpointLog.EndpointLog", b =>
                {
                    b.HasOne("CleanAdArch.Domain.Models.User.User", "User")
                        .WithMany("EndpointLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.RefreshToken.RefreshToken", b =>
                {
                    b.HasOne("CleanAdArch.Domain.Models.User.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.SubCategory.SubCategory", b =>
                {
                    b.HasOne("CleanAdArch.Domain.Models.Category.Category", "Category")
                        .WithMany("SubCats")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.Category.Category", b =>
                {
                    b.Navigation("AdsList");

                    b.Navigation("SubCats");
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.City.City", b =>
                {
                    b.Navigation("AdsList");
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.SubCategory.SubCategory", b =>
                {
                    b.Navigation("AdsList");
                });

            modelBuilder.Entity("CleanAdArch.Domain.Models.User.User", b =>
                {
                    b.Navigation("AdsList");

                    b.Navigation("EndpointLogs");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
