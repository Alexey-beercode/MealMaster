using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealMaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updated_user_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("11cdaf91-5b19-46b6-bb2f-816d06cdeb89"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("5b4bd099-1366-43d3-9fac-cafb74c32d25"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("6294bd11-b8d4-4fb1-9ecf-12010cfc44c3"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("7b6541e6-5b6b-4a4f-a132-66bb747887ec"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("8689e938-9b77-47af-9313-f9832cd4b251"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("ba55b0eb-b230-4aab-843e-87f2e32a1b98"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("bdaa918d-819c-4ca0-be25-91baf1cf0326"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("ca3aec54-a6b6-47bb-8fd4-c142d685b091"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("d3e94e6f-7234-4f58-800c-309a888891f8"));

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: new Guid("e975b9ea-acaa-4c16-b44a-c77a066e59cb"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("188a4031-96fd-4864-98a9-bf339f1c012f"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("9e8fd88a-75f3-4802-9a63-4d28f32b0333"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("b805814e-fe99-4b1c-984f-9078b74a54e7"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("c17c7d88-e32c-4d26-9365-90e46d867437"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("d275e3a7-979b-40a6-b546-17fddb8054fd"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("e67fb98a-894b-4924-9188-221562818c33"));

            migrationBuilder.DeleteData(
                table: "DietaryRestrictions",
                keyColumn: "Id",
                keyValue: new Guid("fc2915fc-a62f-4cc4-8ae8-2c4648db7a67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("038ab599-86b0-4f5b-850b-40c3b3bcd7ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0558b532-6e97-4f35-a54b-b6bec5045abc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0baf1228-8dbb-41e6-a685-69f9588402fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0edf6bfd-99f9-4109-bc49-2d0c7529e0c2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("117ed9cd-9692-4abc-b1b8-cc1c14c0367f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1eb80aa0-6be7-4d08-8d0a-2fa98eeab8ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4451aa95-54b5-431f-9472-03bc05e40cdf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44d58684-d746-465d-baaa-be066f42f5bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4730e71e-8bd0-488a-b169-a4dcf56139cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53a0ad48-8eef-4420-9fad-1268886fd021"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53d59b79-7206-47c0-867e-c3b286041188"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5925fd38-194d-4b18-98d5-631b06c10137"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a7f5ecf-2a25-4777-b89d-326d373b4410"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65fec9d1-3989-4978-9f5b-85562c568590"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6dbd8b04-fbff-4394-8308-ec5160036e24"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70437b7d-18d8-4bc0-9fdb-84492ceb7afe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("882726b3-73c2-4829-82b7-f71c80cbed8f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8869314d-5031-4425-ab8b-fa9ea37a1464"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b38f129-f683-4d34-a3a4-1667526b288b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b7ad343-97ed-4129-badf-d9f4d847827d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95be5955-d504-47c5-9c88-d50c3d245a33"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9e052544-b5d0-41b3-9025-e3dfded68b70"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b1ef8dce-8805-4d5f-bdd8-0e48c24b94fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c81eeff4-e1d3-4ed5-a4b1-4bab466fe5e3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e029e174-9a92-4d0a-885f-da3e14894daf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6c30c5b-e2a0-4c4c-bf4d-a32f1f7082f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f835cd42-a68b-46ce-943e-b1b17c0e292e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc6e8836-bab8-4132-984b-4ea216d0b930"));

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
        }
    }
}
