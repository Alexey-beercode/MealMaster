using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealMaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updated_user_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("1eceba06-b066-4d03-8312-fbb4b783cc63"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("3abc200b-6369-479f-bc4c-1c3eff6e45b0"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("65ff2dca-4b95-4d43-be7a-d969f2e551cc"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("970ed01c-2c96-42c8-b5fd-5db347eb9e6c"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("a6bba301-cbf8-4cef-a22d-a89e6935c7e8"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("c19c4115-93c6-4d1e-90be-36592e37c65d"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc35c0d4-3a56-487f-9a49-b0b921feab8e"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("d32011db-8895-483a-a10b-62d547e352fe"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("dcecab01-9625-4cb0-a28b-34878df6357e"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4ddebb2-289c-4fa3-95b0-fbcbc839b591"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("06ced0e8-fec1-4625-8d3a-67a0012f1603"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("134f94fe-4c85-4ccd-8dff-8d00e8fd9e1a"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("1702957d-19f9-4180-9a00-0e2c5fd45515"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("93dedd30-5ceb-4b36-b6b8-0c97ad9404b1"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("975eb017-56df-4556-b2b9-006c8e0796f4"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("e0b2c6fe-19d5-4e9d-b43b-cfe44d110158"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("f96c909a-aaa1-4d22-b2e6-8c08107bb841"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("06386f49-9b8d-4051-9c52-09f046dc9fb6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c6d2445-e6ea-4002-bdf3-8a8d5288a7c6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d7fd82d-6474-428f-9c01-490028138a94"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15e70ada-6e93-425d-9d60-a453dfc889d2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2190020a-eacc-471a-866e-5ea1682f5b34"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2ba52c30-59cd-4a3a-892a-ca47b19f10b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e41c934-1d39-447a-9cec-71a72ed36bc7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e888b86-6760-447f-a8ef-f3bbf1be6df0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41d2081e-76e3-4519-904c-47cd63bb5dc2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("454aa185-2c00-4848-a140-fff89f7ccabb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54cd8eec-a46e-471b-b507-16930728121f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("63cbc995-a396-422d-a144-6f0ad795ca93"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("675490d5-fd3b-48a7-8757-cfac00aa1195"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d843684-05d6-47bc-b44a-9ed0ee16a1b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e1fced8-8edd-4764-86ad-9a350fe83b30"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("802ba8ed-311a-4970-9034-a0043646c254"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8046b3d2-b28a-4972-af6b-13dee7ae1609"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("954c3f8d-419e-41e1-a607-4d7f20a9f591"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a30d1934-21c4-4d6d-801a-83bdb7ee06e0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b352f597-3e95-404a-90bb-b5197a5f19dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2601e29-b656-4d97-b292-46a5f95e6e47"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d427dcac-95ee-414e-a9a8-377fe0721fa9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4f2b27c-fcde-4d42-828c-e16b4095983c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da011b1f-893a-49df-9402-84c6afb56f4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dc4c6841-4a8e-47d2-ae27-74cea002c97a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e447f678-b612-45e8-91a8-a7eec27b34fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa3dc11b-2a9b-4d3c-af70-a0179a57962f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe3b87f8-8319-42de-8983-68250505467c"));

            migrationBuilder.InsertData(
                table: "CuisineTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("089154d5-79d5-4536-9312-7f8fcdd8fda3"), false, "Мексиканская" },
                    { new Guid("08e23047-b751-40de-92e8-43d574eb8335"), false, "Итальянская" },
                    { new Guid("0f213aec-2e11-4752-a213-57ea2cb3b8e7"), false, "Испанская" },
                    { new Guid("4fc0e6b8-d08b-4547-ad3a-eb38a63d3044"), false, "Американская" },
                    { new Guid("5d72c2f1-a3f7-430d-9c2f-11ca66ee9d81"), false, "Белорусская" },
                    { new Guid("6cf79fba-9217-4d13-9aa2-51aedd03104b"), false, "Тайская" },
                    { new Guid("9e42a430-ced2-45fe-bf23-6f92c5ada21d"), false, "Французская" },
                    { new Guid("a3cc00db-102d-43cd-8cf8-633300951928"), false, "Японская" },
                    { new Guid("dab599a1-0aff-4117-ad5e-cb25327c3e68"), false, "Русская" },
                    { new Guid("f02e2d3c-7735-48ab-90fe-fe338ec44d57"), false, "Китайская" }
                });

            migrationBuilder.InsertData(
                table: "DietaryRestrictions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("472941d0-e498-445a-a162-b9bb8c534725"), false, "Кето" },
                    { new Guid("4747f411-5ae9-4622-ad5e-c4239b3deada"), false, "Безглютеновое" },
                    { new Guid("59d9818e-bb66-48c3-a12f-f1bcf474f399"), false, "Вегетарианское" },
                    { new Guid("90a5655f-306d-47ca-9b41-61397587ff0a"), false, "Палео" },
                    { new Guid("92c5f01f-80ab-45f1-a74d-7f8d9d34d44f"), false, "Безлактозное" },
                    { new Guid("b3c47249-fd0b-47a4-b796-8ce55fa2c102"), false, "Диабетическое" },
                    { new Guid("ce7aa8cb-1fa6-40e0-a083-296b9fe007db"), false, "Веганское" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("04393948-97a2-4d50-bf33-acf261225295"), false, "Перец" },
                    { new Guid("13330f16-1ad5-4a11-b4af-d650e4be4a68"), false, "Капуста" },
                    { new Guid("16d6e488-65dd-43b5-9ae3-f2cea6e1f3b6"), false, "Паста" },
                    { new Guid("19abef49-08f9-46ff-8d5c-fd50863c3f05"), false, "Лук" },
                    { new Guid("2e68a284-e64b-46a6-bfe1-7edccf5db6df"), false, "Бекон" },
                    { new Guid("32061e4e-a2c1-4f95-b726-8b92b97f2fb4"), false, "Шпинат" },
                    { new Guid("46ef97e0-4549-408d-8f6a-477827a7568e"), false, "Гречка" },
                    { new Guid("58fe7fe8-9ca7-449f-adff-5be021723955"), false, "Грибы" },
                    { new Guid("5b484f75-e66a-4213-ab0d-2c0fe42b74b7"), false, "Масло сливочное" },
                    { new Guid("68528ea8-4109-4e2c-9596-e60f469d8a5c"), false, "Свинина" },
                    { new Guid("6abba270-f0bd-4220-9922-c485c9b013d4"), false, "Тунец" },
                    { new Guid("743c96c8-7dbc-4d4b-88e1-3884a0e65988"), false, "Картофель" },
                    { new Guid("8a3927e8-0a11-472e-96f4-5aed54467bbf"), false, "Креветки" },
                    { new Guid("8a774d16-dfae-4d49-a4d2-e6eb1de451db"), false, "Брокколи" },
                    { new Guid("8fd2abc2-7b95-4d0e-a58b-a2079a97904e"), false, "Сыр" },
                    { new Guid("96d5ddea-8f27-4d26-8758-eaa5f4f5889f"), false, "Сметана" },
                    { new Guid("97b76ee4-cb35-45ad-8880-3f34ecd65f64"), false, "Помидоры" },
                    { new Guid("9fdcf65b-87bc-4ce1-8ded-2e366cc6e030"), false, "Чеснок" },
                    { new Guid("b8c12027-695a-4ec7-8fa8-9cda3bf776cf"), false, "Яйца" },
                    { new Guid("c30c5b64-7414-46ab-bea9-ba9061b894d0"), false, "Говядина" },
                    { new Guid("c8bf97ae-0a29-4eba-a0d1-84b5d59d13e1"), false, "Авокадо" },
                    { new Guid("d0ffb849-2669-4d3e-ae7a-c45b10521719"), false, "Огурцы" },
                    { new Guid("d12b2b22-b0c2-4e63-b38e-07b43ec9b073"), false, "Курица" },
                    { new Guid("d4eb6d82-7eb1-4c5c-a108-b83f86954224"), false, "Мука" },
                    { new Guid("da9437b3-9c13-47f6-8934-0f0440ca5719"), false, "Морковь" },
                    { new Guid("dd9eac3c-3d1a-44a2-8c9c-83486d3071e0"), false, "Рис" },
                    { new Guid("e64c4218-3e28-4b0a-a64e-09e935785aff"), false, "Лосось" },
                    { new Guid("f8107393-2d49-4aa9-ba30-edf3008af4d9"), false, "Молоко" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("089154d5-79d5-4536-9312-7f8fcdd8fda3"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("08e23047-b751-40de-92e8-43d574eb8335"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("0f213aec-2e11-4752-a213-57ea2cb3b8e7"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("4fc0e6b8-d08b-4547-ad3a-eb38a63d3044"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("5d72c2f1-a3f7-430d-9c2f-11ca66ee9d81"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("6cf79fba-9217-4d13-9aa2-51aedd03104b"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e42a430-ced2-45fe-bf23-6f92c5ada21d"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("a3cc00db-102d-43cd-8cf8-633300951928"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("dab599a1-0aff-4117-ad5e-cb25327c3e68"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("f02e2d3c-7735-48ab-90fe-fe338ec44d57"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("472941d0-e498-445a-a162-b9bb8c534725"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("4747f411-5ae9-4622-ad5e-c4239b3deada"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("59d9818e-bb66-48c3-a12f-f1bcf474f399"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("90a5655f-306d-47ca-9b41-61397587ff0a"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("92c5f01f-80ab-45f1-a74d-7f8d9d34d44f"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("b3c47249-fd0b-47a4-b796-8ce55fa2c102"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("ce7aa8cb-1fa6-40e0-a083-296b9fe007db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("04393948-97a2-4d50-bf33-acf261225295"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13330f16-1ad5-4a11-b4af-d650e4be4a68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("16d6e488-65dd-43b5-9ae3-f2cea6e1f3b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("19abef49-08f9-46ff-8d5c-fd50863c3f05"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e68a284-e64b-46a6-bfe1-7edccf5db6df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32061e4e-a2c1-4f95-b726-8b92b97f2fb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46ef97e0-4549-408d-8f6a-477827a7568e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58fe7fe8-9ca7-449f-adff-5be021723955"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5b484f75-e66a-4213-ab0d-2c0fe42b74b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("68528ea8-4109-4e2c-9596-e60f469d8a5c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6abba270-f0bd-4220-9922-c485c9b013d4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("743c96c8-7dbc-4d4b-88e1-3884a0e65988"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a3927e8-0a11-472e-96f4-5aed54467bbf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a774d16-dfae-4d49-a4d2-e6eb1de451db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8fd2abc2-7b95-4d0e-a58b-a2079a97904e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96d5ddea-8f27-4d26-8758-eaa5f4f5889f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97b76ee4-cb35-45ad-8880-3f34ecd65f64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fdcf65b-87bc-4ce1-8ded-2e366cc6e030"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b8c12027-695a-4ec7-8fa8-9cda3bf776cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c30c5b64-7414-46ab-bea9-ba9061b894d0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8bf97ae-0a29-4eba-a0d1-84b5d59d13e1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d0ffb849-2669-4d3e-ae7a-c45b10521719"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d12b2b22-b0c2-4e63-b38e-07b43ec9b073"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4eb6d82-7eb1-4c5c-a108-b83f86954224"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da9437b3-9c13-47f6-8934-0f0440ca5719"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd9eac3c-3d1a-44a2-8c9c-83486d3071e0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e64c4218-3e28-4b0a-a64e-09e935785aff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f8107393-2d49-4aa9-ba30-edf3008af4d9"));

            migrationBuilder.InsertData(
                table: "CuisineTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("1eceba06-b066-4d03-8312-fbb4b783cc63"), false, "Американская" },
                    { new Guid("3abc200b-6369-479f-bc4c-1c3eff6e45b0"), false, "Русская" },
                    { new Guid("65ff2dca-4b95-4d43-be7a-d969f2e551cc"), false, "Мексиканская" },
                    { new Guid("970ed01c-2c96-42c8-b5fd-5db347eb9e6c"), false, "Белорусская" },
                    { new Guid("a6bba301-cbf8-4cef-a22d-a89e6935c7e8"), false, "Испанская" },
                    { new Guid("c19c4115-93c6-4d1e-90be-36592e37c65d"), false, "Китайская" },
                    { new Guid("cc35c0d4-3a56-487f-9a49-b0b921feab8e"), false, "Итальянская" },
                    { new Guid("d32011db-8895-483a-a10b-62d547e352fe"), false, "Японская" },
                    { new Guid("dcecab01-9625-4cb0-a28b-34878df6357e"), false, "Французская" },
                    { new Guid("f4ddebb2-289c-4fa3-95b0-fbcbc839b591"), false, "Тайская" }
                });

            migrationBuilder.InsertData(
                table: "DietaryRestrictions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("06ced0e8-fec1-4625-8d3a-67a0012f1603"), false, "Безглютеновое" },
                    { new Guid("134f94fe-4c85-4ccd-8dff-8d00e8fd9e1a"), false, "Кето" },
                    { new Guid("1702957d-19f9-4180-9a00-0e2c5fd45515"), false, "Веганское" },
                    { new Guid("93dedd30-5ceb-4b36-b6b8-0c97ad9404b1"), false, "Безлактозное" },
                    { new Guid("975eb017-56df-4556-b2b9-006c8e0796f4"), false, "Вегетарианское" },
                    { new Guid("e0b2c6fe-19d5-4e9d-b43b-cfe44d110158"), false, "Палео" },
                    { new Guid("f96c909a-aaa1-4d22-b2e6-8c08107bb841"), false, "Диабетическое" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("06386f49-9b8d-4051-9c52-09f046dc9fb6"), false, "Грибы" },
                    { new Guid("0c6d2445-e6ea-4002-bdf3-8a8d5288a7c6"), false, "Говядина" },
                    { new Guid("0d7fd82d-6474-428f-9c01-490028138a94"), false, "Лосось" },
                    { new Guid("15e70ada-6e93-425d-9d60-a453dfc889d2"), false, "Сыр" },
                    { new Guid("2190020a-eacc-471a-866e-5ea1682f5b34"), false, "Паста" },
                    { new Guid("2ba52c30-59cd-4a3a-892a-ca47b19f10b3"), false, "Перец" },
                    { new Guid("2e41c934-1d39-447a-9cec-71a72ed36bc7"), false, "Лук" },
                    { new Guid("3e888b86-6760-447f-a8ef-f3bbf1be6df0"), false, "Картофель" },
                    { new Guid("41d2081e-76e3-4519-904c-47cd63bb5dc2"), false, "Молоко" },
                    { new Guid("454aa185-2c00-4848-a140-fff89f7ccabb"), false, "Свинина" },
                    { new Guid("54cd8eec-a46e-471b-b507-16930728121f"), false, "Курица" },
                    { new Guid("63cbc995-a396-422d-a144-6f0ad795ca93"), false, "Креветки" },
                    { new Guid("675490d5-fd3b-48a7-8757-cfac00aa1195"), false, "Чеснок" },
                    { new Guid("6d843684-05d6-47bc-b44a-9ed0ee16a1b7"), false, "Сметана" },
                    { new Guid("7e1fced8-8edd-4764-86ad-9a350fe83b30"), false, "Морковь" },
                    { new Guid("802ba8ed-311a-4970-9034-a0043646c254"), false, "Тунец" },
                    { new Guid("8046b3d2-b28a-4972-af6b-13dee7ae1609"), false, "Брокколи" },
                    { new Guid("954c3f8d-419e-41e1-a607-4d7f20a9f591"), false, "Огурцы" },
                    { new Guid("a30d1934-21c4-4d6d-801a-83bdb7ee06e0"), false, "Яйца" },
                    { new Guid("b352f597-3e95-404a-90bb-b5197a5f19dd"), false, "Бекон" },
                    { new Guid("d2601e29-b656-4d97-b292-46a5f95e6e47"), false, "Помидоры" },
                    { new Guid("d427dcac-95ee-414e-a9a8-377fe0721fa9"), false, "Мука" },
                    { new Guid("d4f2b27c-fcde-4d42-828c-e16b4095983c"), false, "Шпинат" },
                    { new Guid("da011b1f-893a-49df-9402-84c6afb56f4f"), false, "Масло сливочное" },
                    { new Guid("dc4c6841-4a8e-47d2-ae27-74cea002c97a"), false, "Авокадо" },
                    { new Guid("e447f678-b612-45e8-91a8-a7eec27b34fe"), false, "Рис" },
                    { new Guid("fa3dc11b-2a9b-4d3c-af70-a0179a57962f"), false, "Гречка" },
                    { new Guid("fe3b87f8-8319-42de-8983-68250505467c"), false, "Капуста" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }
    }
}
