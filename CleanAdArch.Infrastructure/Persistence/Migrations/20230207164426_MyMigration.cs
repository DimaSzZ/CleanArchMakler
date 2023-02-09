using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanAdArch.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryproduct = table.Column<string>(name: "category_product", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cityname = table.Column<string>(name: "city_name", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    hashedpassword = table.Column<string>(name: "hashed_password", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subcategories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    subcategoryproduct = table.Column<string>(name: "subcategory_product", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_subcategories_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "endpoints_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    accesstoken = table.Column<string>(name: "access_token", type: "text", nullable: true, defaultValue: "Anonymous"),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    request = table.Column<object>(type: "jsonb", nullable: false),
                    response = table.Column<object>(type: "jsonb", nullable: false),
                    respondedat = table.Column<DateTime>(name: "responded_at", type: "timestamp", nullable: false),
                    statuscode = table.Column<int>(name: "status_code", type: "integer", nullable: false),
                    elapsedtime = table.Column<TimeSpan>(name: "elapsed_time", type: "interval", nullable: false),
                    method = table.Column<string>(type: "text", nullable: false),
                    handlername = table.Column<string>(name: "handler_name", type: "text", nullable: false),
                    errordescription = table.Column<string>(name: "error_description", type: "text", nullable: true),
                    exceptionname = table.Column<string>(name: "exception_name", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endpoints_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_endpoints_logs_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    token = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    expiresat = table.Column<DateTime>(name: "expires_at", type: "timestamp", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp", nullable: false),
                    revoked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => x.token);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    heading = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    dateofcreate = table.Column<DateTime>(name: "date_of_create", type: "date", nullable: false),
                    picture = table.Column<string>(type: "text", nullable: true),
                    categoryid = table.Column<Guid>(name: "category_id", type: "uuid", nullable: false),
                    subcategoryid = table.Column<Guid>(name: "sub_category_id", type: "uuid", nullable: false),
                    cityid = table.Column<Guid>(name: "city_id", type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ads_categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_cities_city_id",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_subcategories_sub_category_id",
                        column: x => x.subcategoryid,
                        principalTable: "subcategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_category_id",
                table: "Ads",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_city_id",
                table: "Ads",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_sub_category_id",
                table: "Ads",
                column: "sub_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_user_id",
                table: "Ads",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_endpoints_logs_user_id",
                table: "endpoints_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_user_id",
                table: "refresh_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_subcategories_categoryId",
                table: "subcategories",
                column: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "endpoints_logs");

            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "subcategories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
