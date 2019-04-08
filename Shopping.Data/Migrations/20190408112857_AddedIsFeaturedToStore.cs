using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Data.Migrations
{
    public partial class AddedIsFeaturedToStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Stores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RecentlyDisplayedProduct",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    DisplayDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentlyDisplayedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecentlyDisplayedProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "109057a8-d4c0-40c5-bede-a238dcdf0245",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8638), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "45ee14ef-d408-47e3-b104-01a9e23c5def",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8629), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "6d85aacb-8f1b-4488-b5bd-5390b9cd76c6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8607), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "be084f87-b383-4939-a1db-97c9d16ce295",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8650), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "c047e1e6-01d1-47d9-8087-ad1b3400ad0e",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8625), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "d228e627-feb9-4208-9a10-b3ac8dc866fa",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8641), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "e8840d39-abf2-4577-bfa5-a92144107b09",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8274), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "f3bf46ec-4135-4f13-b874-b6d0fea16ada",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8594), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8597) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "ff23d5c6-d2b6-4687-a715-299ee0c5dd25",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8647), new DateTime(2019, 4, 8, 14, 28, 55, 627, DateTimeKind.Local).AddTicks(8647) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "1f2f8408-9ad2-4908-b310-92dbdabe5979",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(718), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(721) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 621, DateTimeKind.Local).AddTicks(5438), new DateTime(2019, 4, 8, 14, 28, 55, 622, DateTimeKind.Local).AddTicks(5909) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(708), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "4b64df99-8909-4fb4-bc23-9a84e5063f27",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(724), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b0",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(677), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(385), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(643), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(646) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(655), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(655) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(658), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b5",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(674), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(702), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(683), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(686) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b8",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(690), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(690) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(696), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(699) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "8da13d65-1efb-40ea-b88f-08b06d0776ab",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(730), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "ed515341-522e-4bfa-8f68-15c874fd77e9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(714), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "077e4e64-313e-4d4e-a340-5c84e0a3d748",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6530), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "12c5d0df-7ac8-4a6c-8f59-aa4037940c1b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6498), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "3e4cc993-9f23-4bb7-a943-59c3cf7fc166",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(5839), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(5852) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "54a82e8b-de71-4f99-9841-4431e78b7552",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6523), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6523) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "7778feda-520c-4157-a80e-0bee5ee57511",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6536), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6536) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "85dfb6e4-908d-45c1-b414-a488b6891197",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6508), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6508) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "c7e447b9-fcbe-43e7-a46c-1a578400fa8e",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6545), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6548) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "cf363e7a-b99a-425f-8d07-50487081049b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6390), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "d5266161-dff1-4c09-9a36-d84ac5cc3b1b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6514), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6514) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "df2bd20c-176a-4392-a918-f0e8509c9161",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6533), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "f9a0eaa5-2934-4097-8c09-551d3cf8b48b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6542), new DateTime(2019, 4, 8, 14, 28, 55, 638, DateTimeKind.Local).AddTicks(6542) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7534), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7537) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1db450c1-594b-4bed-b726-d4462a4d54f6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7611), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7615) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7002), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4330ef04-db35-4358-936a-d4db324d4fed",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7543), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "48ffccbf-b72e-4328-a5eb-cf487863589c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7621), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7621) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5e575e49-7724-4527-9ee9-15f4718c0778",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7602), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "700fe299-bb99-47a1-acd5-d614016a374e",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7596), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7596) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7b4ff888-2e18-4490-b01a-76c4a7b3095b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7518), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7521) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7fdad843-e55c-4003-8b6a-486344e6d8cb",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7580), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "cd9d729e-b245-4606-b480-4e90b94a3882",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7587), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "fe01d29b-f753-4b89-a6e8-a502de6cfbe1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7552), new DateTime(2019, 4, 8, 14, 28, 55, 635, DateTimeKind.Local).AddTicks(7552) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "86b27fee-aa1a-4552-9bcd-6c8100b11138",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5532), new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5544) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "a19e279f-65b3-4b9d-b658-037c9b763aac",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5967), new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "a93dffde-741e-45bc-8aab-8976e03c172d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5952), new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5955) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "ad673d9a-ff2d-4cb0-bcac-5587f08d2ffc",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5973), new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "c35776e9-c002-4af9-8553-eb9e466b8910",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5964), new DateTime(2019, 4, 8, 14, 28, 55, 640, DateTimeKind.Local).AddTicks(5964) });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: "b5616904-9304-40ab-9488-5d4809021445",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(8676), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: "d1689024-2cff-420d-a2aa-141e93cbbff7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(8975), new DateTime(2019, 4, 8, 14, 28, 55, 623, DateTimeKind.Local).AddTicks(8975) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "007f78d2-f4d5-413a-9a80-737bc6850d5d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(4818), new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(4824) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "072df9fd-ef97-40f4-a10e-5b0e7dc3f08c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5145), new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5145) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "0c0d6d02-c99a-4537-9821-f2c90f21f451",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5135), new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5135) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "3a64713c-22b6-48ff-8d84-740dcefdbd37",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5123), new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5126) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "cc3fc344-2141-40c5-be49-3b9c661d56b2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5139), new DateTime(2019, 4, 8, 14, 28, 55, 625, DateTimeKind.Local).AddTicks(5142) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: "f544e6dd-70c7-4c99-834e-8147e1bff9f1",
                column: "IsFeatured",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecentlyDisplayedProduct_ProductId",
                table: "RecentlyDisplayedProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecentlyDisplayedProduct");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Stores");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "109057a8-d4c0-40c5-bede-a238dcdf0245",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2694), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2694) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "45ee14ef-d408-47e3-b104-01a9e23c5def",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2682), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2685) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "6d85aacb-8f1b-4488-b5bd-5390b9cd76c6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2669), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2672) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "be084f87-b383-4939-a1db-97c9d16ce295",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2710), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2710) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "c047e1e6-01d1-47d9-8087-ad1b3400ad0e",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2678), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2678) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "d228e627-feb9-4208-9a10-b3ac8dc866fa",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2700), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "e8840d39-abf2-4577-bfa5-a92144107b09",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2150), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2162) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "f3bf46ec-4135-4f13-b874-b6d0fea16ada",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2660), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "ff23d5c6-d2b6-4687-a715-299ee0c5dd25",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2703), new DateTime(2019, 4, 1, 14, 25, 17, 348, DateTimeKind.Local).AddTicks(2703) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "1f2f8408-9ad2-4908-b310-92dbdabe5979",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(567), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(567) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 340, DateTimeKind.Local).AddTicks(1988), new DateTime(2019, 4, 1, 14, 25, 17, 341, DateTimeKind.Local).AddTicks(4758) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(539), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(539) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "4b64df99-8909-4fb4-bc23-9a84e5063f27",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(580), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(583) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b0",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(346), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(349) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(32), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(45) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(287), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(309), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(309) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(318), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(321) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b5",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(337), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(337) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(521), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(524) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(359), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(359) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b8",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(365), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(368) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "6d8135c2-833f-42fc-900d-6eeeb1c607b9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(502), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(505) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "8da13d65-1efb-40ea-b88f-08b06d0776ab",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(592), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(595) });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: "ed515341-522e-4bfa-8f68-15c874fd77e9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(552), new DateTime(2019, 4, 1, 14, 25, 17, 342, DateTimeKind.Local).AddTicks(555) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "077e4e64-313e-4d4e-a340-5c84e0a3d748",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8095), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "12c5d0df-7ac8-4a6c-8f59-aa4037940c1b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8070), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "3e4cc993-9f23-4bb7-a943-59c3cf7fc166",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(7501), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "54a82e8b-de71-4f99-9841-4431e78b7552",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8092), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "7778feda-520c-4157-a80e-0bee5ee57511",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8104), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8104) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "85dfb6e4-908d-45c1-b414-a488b6891197",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8076), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8076) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "c7e447b9-fcbe-43e7-a46c-1a578400fa8e",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8113), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "cf363e7a-b99a-425f-8d07-50487081049b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8057), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8061) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "d5266161-dff1-4c09-9a36-d84ac5cc3b1b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8079), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8082) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "df2bd20c-176a-4392-a918-f0e8509c9161",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8101), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "ProductPhotos",
                keyColumn: "Id",
                keyValue: "f9a0eaa5-2934-4097-8c09-551d3cf8b48b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8110), new DateTime(2019, 4, 1, 14, 25, 17, 360, DateTimeKind.Local).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9902), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1db450c1-594b-4bed-b726-d4462a4d54f6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 358, DateTimeKind.Local).AddTicks(36), new DateTime(2019, 4, 1, 14, 25, 17, 358, DateTimeKind.Local).AddTicks(36) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9109), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9121) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4330ef04-db35-4358-936a-d4db324d4fed",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9914), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9914) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "48ffccbf-b72e-4328-a5eb-cf487863589c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 358, DateTimeKind.Local).AddTicks(48), new DateTime(2019, 4, 1, 14, 25, 17, 358, DateTimeKind.Local).AddTicks(48) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5e575e49-7724-4527-9ee9-15f4718c0778",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9961), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9961) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "700fe299-bb99-47a1-acd5-d614016a374e",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9955), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9955) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7b4ff888-2e18-4490-b01a-76c4a7b3095b",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9883), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7fdad843-e55c-4003-8b6a-486344e6d8cb",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9936), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9936) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "cd9d729e-b245-4606-b480-4e90b94a3882",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9945), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "fe01d29b-f753-4b89-a6e8-a502de6cfbe1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9921), new DateTime(2019, 4, 1, 14, 25, 17, 357, DateTimeKind.Local).AddTicks(9924) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "86b27fee-aa1a-4552-9bcd-6c8100b11138",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6277), new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6283) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "a19e279f-65b3-4b9d-b658-037c9b763aac",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6687), new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "a93dffde-741e-45bc-8aab-8976e03c172d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6672), new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "ad673d9a-ff2d-4cb0-bcac-5587f08d2ffc",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6693), new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6693) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "c35776e9-c002-4af9-8553-eb9e466b8910",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6684), new DateTime(2019, 4, 1, 14, 25, 17, 362, DateTimeKind.Local).AddTicks(6684) });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: "b5616904-9304-40ab-9488-5d4809021445",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 343, DateTimeKind.Local).AddTicks(594), new DateTime(2019, 4, 1, 14, 25, 17, 343, DateTimeKind.Local).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: "d1689024-2cff-420d-a2aa-141e93cbbff7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 343, DateTimeKind.Local).AddTicks(989), new DateTime(2019, 4, 1, 14, 25, 17, 343, DateTimeKind.Local).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "007f78d2-f4d5-413a-9a80-737bc6850d5d",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(2464), new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(2477) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "072df9fd-ef97-40f4-a10e-5b0e7dc3f08c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3149), new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3149) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "0c0d6d02-c99a-4537-9821-f2c90f21f451",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3046), new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "3a64713c-22b6-48ff-8d84-740dcefdbd37",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3037), new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: "cc3fc344-2141-40c5-be49-3b9c661d56b2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3052), new DateTime(2019, 4, 1, 14, 25, 17, 345, DateTimeKind.Local).AddTicks(3052) });
        }
    }
}
