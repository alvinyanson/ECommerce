using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedProductTableAndProductCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BriefDescription", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Twin Lens Camera", "Twin Lens Camera", "images\\product\\e30fdaf9-489c-4a4c-b933-ef698f1d28e0.jpg", "Twin Lens Camera", 1000.0 },
                    { 2, "Compact SLR Camera", "Compact SLR Camera", "images\\product\\cedff5d3-ed2a-4b6b-8157-3e0293eb61bd.jpg", "Compact SLR Camera", 1000.0 },
                    { 3, "Nikkormat SLR Camera", "Nikkormat SLR Camera", "images\\product\\092b7d67-1010-43b9-8c4f-f8f674947edf.jpg", "Nikkormat SLR Camera", 1900.0 },
                    { 4, "Compact Digital Camera", "Compact Digital Camera", "images\\product\\b7f4cb2c-42c5-43c8-b41d-61d63a7d95f2.jpg", "Compact Digital Camera", 1900.0 },
                    { 5, "Instamatic Camera", "Instamatic Camera", "images\\product\\43d302da-06bb-4b78-a55b-822ecb114257.jpg", "Instamatic Camera", 1900.0 },
                    { 6, "Tripod", "Tripod", "images\\product\\5ad3224c-b2ba-425c-8973-6ea79a8bd940.jpg", "Tripod", 1000.0 },
                    { 7, "Vintage Folding Camera", "Vintage Folding Camera", "images\\product\\cb38d263-938a-48dd-87b9-05b458ca3032.jpg", "Vintage Folding Camera", 1000.0 },
                    { 8, "Camera Lens", "Camera Lens", "images\\product\\9aa2a2b5-ded2-4bbe-b97d-a09095fa02d5.jpg", "Camera Lens", 1000.0 },
                    { 9, "Instant Camera", "Instant Camera", "images\\product\\2ceab055-200f-4817-bd5f-52d12ce09921.jpg", "Instant Camera", 1000.0 },
                    { 10, "USB Cable", "USB Cable", "images\\product\\48ff9ac1-006f-4a81-8847-2357cd648ed4.jpg", "USB Cable", 1600.0 },
                    { 11, "Ethernet Cable", "Ethernet Cable", "images\\product\\f88f2194-1e60-411a-b268-2eae125705d5.jpg", "Ethernet Cable", 100.0 },
                    { 12, "Clacky Keyboard", "Clacky Keyboard", "images\\product\\daf3a747-30fb-4841-96e0-9f64084307ef.jpg", "Clacky Keyboard", 1000.0 },
                    { 13, "Hard Drive", "Hard Drive", "images\\product\\6e13c1da-a19b-4827-88ba-91498e3f2241.jpg", "Hard Drive", 1000.0 },
                    { 14, "Gaming PC", "Gaming PC", "images\\product\\4ac6662f-639d-480b-b318-8875943321e5.jpg", "Gaming PC", 1000.0 },
                    { 15, "High Performance RAM", "High Performance RAM", "images\\product\\accc318f-38df-4c5f-a0f5-91c98948a2ea.jpg", "High Performance RAM", 1000.0 },
                    { 16, "Curvy Monitor", "Curvy Monitor", "images\\product\\1497ba90-2c8a-4a71-90f2-c970e1a0214f.jpg", "Curvy Monitor", 1000.0 },
                    { 17, "32-Inch Monitor", "32-Inch Monitor", "images\\product\\f990bf34-3cbf-47ac-a0d0-296d3f282474.jpg", "32-Inch Monitor", 1900.0 },
                    { 18, "Wireless Optical Mouse", "Wireless Optical Mouse", "images\\product\\5aa66166-310c-435e-bafa-5f6d8f9ca384.jpg", "Wireless Optical Mouse", 1000.0 },
                    { 19, "Tablet", "Tablet", "images\\product\\25cf7661-618f-4281-bcd3-c3814e1e5aba.jpg", "Tablet", 1000.0 },
                    { 20, "Laptop", "Laptop", "images\\product\\771af035-72f6-42c7-998b-b38f3775e99d.jpg", "Laptop", 1000.0 },
                    { 21, "Grey Fabric Sofa", "Grey Fabric Sofa", "images\\product\\66f06846-c2f6-45be-aa6e-6c428fcf3396.jpg", "Grey Fabric Sofa", 1000.0 },
                    { 22, "Hi-Top Basketball Shoe", "Hi-Top Basketball Shoe", "images\\product\\45bd9afc-91ad-45d2-ab0a-2fee340b7dc6.jpg", "Hi-Top Basketball Shoe", 250.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 3, 21 },
                    { 5, 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 21 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 22 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
