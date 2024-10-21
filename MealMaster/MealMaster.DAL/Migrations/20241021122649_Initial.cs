using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealMaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuisineTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietaryRestrictions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PortionSize = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalCalories = table.Column<int>(type: "integer", nullable: false),
                    MealCount = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRestrictions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RestrictionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    PreparationTime = table.Column<int>(type: "integer", nullable: false),
                    CuisineTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RestrictionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_CuisineTypes_CuisineTypeId",
                        column: x => x.CuisineTypeId,
                        principalTable: "CuisineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CuisineTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("11cdaf91-5b19-46b6-bb2f-816d06cdeb89"), false, "Японская" },
                    { new Guid("5b4bd099-1366-43d3-9fac-cafb74c32d25"), false, "Мексиканская" },
                    { new Guid("6294bd11-b8d4-4fb1-9ecf-12010cfc44c3"), false, "Русская" },
                    { new Guid("7b6541e6-5b6b-4a4f-a132-66bb747887ec"), false, "Итальянская" },
                    { new Guid("8689e938-9b77-47af-9313-f9832cd4b251"), false, "Американская" },
                    { new Guid("ba55b0eb-b230-4aab-843e-87f2e32a1b98"), false, "Французская" },
                    { new Guid("bdaa918d-819c-4ca0-be25-91baf1cf0326"), false, "Белорусская" },
                    { new Guid("ca3aec54-a6b6-47bb-8fd4-c142d685b091"), false, "Тайская" },
                    { new Guid("d3e94e6f-7234-4f58-800c-309a888891f8"), false, "Китайская" },
                    { new Guid("e975b9ea-acaa-4c16-b44a-c77a066e59cb"), false, "Испанская" }
                });

            migrationBuilder.InsertData(
                table: "DietaryRestrictions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("188a4031-96fd-4864-98a9-bf339f1c012f"), false, "Палео" },
                    { new Guid("9e8fd88a-75f3-4802-9a63-4d28f32b0333"), false, "Веганское" },
                    { new Guid("b805814e-fe99-4b1c-984f-9078b74a54e7"), false, "Диабетическое" },
                    { new Guid("c17c7d88-e32c-4d26-9365-90e46d867437"), false, "Вегетарианское" },
                    { new Guid("d275e3a7-979b-40a6-b546-17fddb8054fd"), false, "Кето" },
                    { new Guid("e67fb98a-894b-4924-9188-221562818c33"), false, "Безлактозное" },
                    { new Guid("fc2915fc-a62f-4cc4-8ae8-2c4648db7a67"), false, "Безглютеновое" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("038ab599-86b0-4f5b-850b-40c3b3bcd7ec"), false, "Рис" },
                    { new Guid("0558b532-6e97-4f35-a54b-b6bec5045abc"), false, "Тунец" },
                    { new Guid("0baf1228-8dbb-41e6-a685-69f9588402fe"), false, "Лук" },
                    { new Guid("0edf6bfd-99f9-4109-bc49-2d0c7529e0c2"), false, "Свинина" },
                    { new Guid("117ed9cd-9692-4abc-b1b8-cc1c14c0367f"), false, "Молоко" },
                    { new Guid("1eb80aa0-6be7-4d08-8d0a-2fa98eeab8ac"), false, "Перец" },
                    { new Guid("4451aa95-54b5-431f-9472-03bc05e40cdf"), false, "Грибы" },
                    { new Guid("44d58684-d746-465d-baaa-be066f42f5bb"), false, "Сыр" },
                    { new Guid("4730e71e-8bd0-488a-b169-a4dcf56139cd"), false, "Морковь" },
                    { new Guid("53a0ad48-8eef-4420-9fad-1268886fd021"), false, "Чеснок" },
                    { new Guid("53d59b79-7206-47c0-867e-c3b286041188"), false, "Бекон" },
                    { new Guid("5925fd38-194d-4b18-98d5-631b06c10137"), false, "Шпинат" },
                    { new Guid("5a7f5ecf-2a25-4777-b89d-326d373b4410"), false, "Яйца" },
                    { new Guid("65fec9d1-3989-4978-9f5b-85562c568590"), false, "Капуста" },
                    { new Guid("6dbd8b04-fbff-4394-8308-ec5160036e24"), false, "Брокколи" },
                    { new Guid("70437b7d-18d8-4bc0-9fdb-84492ceb7afe"), false, "Мука" },
                    { new Guid("882726b3-73c2-4829-82b7-f71c80cbed8f"), false, "Курица" },
                    { new Guid("8869314d-5031-4425-ab8b-fa9ea37a1464"), false, "Паста" },
                    { new Guid("8b38f129-f683-4d34-a3a4-1667526b288b"), false, "Авокадо" },
                    { new Guid("8b7ad343-97ed-4129-badf-d9f4d847827d"), false, "Картофель" },
                    { new Guid("95be5955-d504-47c5-9c88-d50c3d245a33"), false, "Говядина" },
                    { new Guid("9e052544-b5d0-41b3-9025-e3dfded68b70"), false, "Масло сливочное" },
                    { new Guid("b1ef8dce-8805-4d5f-bdd8-0e48c24b94fd"), false, "Сметана" },
                    { new Guid("c81eeff4-e1d3-4ed5-a4b1-4bab466fe5e3"), false, "Помидоры" },
                    { new Guid("e029e174-9a92-4d0a-885f-da3e14894daf"), false, "Огурцы" },
                    { new Guid("f6c30c5b-e2a0-4c4c-bf4d-a32f1f7082f2"), false, "Гречка" },
                    { new Guid("f835cd42-a68b-46ce-943e-b1b17c0e292e"), false, "Креветки" },
                    { new Guid("fc6e8836-bab8-4132-984b-4ea216d0b930"), false, "Лосось" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId_RecipeId",
                table: "MenuItems",
                columns: new[] { "MenuId", "RecipeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CuisineTypeId",
                table: "Recipes",
                column: "CuisineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestrictions_UserId_RestrictionId",
                table: "UserRestrictions",
                columns: new[] { "UserId", "RestrictionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietaryRestrictions");

            migrationBuilder.DropTable(
                name: "MenuHistories");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RecipeProducts");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "UserRestrictions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CuisineTypes");
        }
    }
}
