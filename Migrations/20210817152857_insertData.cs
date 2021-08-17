using Microsoft.EntityFrameworkCore.Migrations;

namespace learnAspDotNetCore.Migrations
{
    public partial class insertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empployees",
                columns: new[] { "Id", "Departement", "Email", "ImageUrl", "Name" },
                values: new object[] { 1, 5, "ali@email.com", "/Images/1.jpg", "ali" });

            migrationBuilder.InsertData(
                table: "Empployees",
                columns: new[] { "Id", "Departement", "Email", "ImageUrl", "Name" },
                values: new object[] { 2, 4, "youcef@email.com", "/Images/2.jpg", "youcef" });

            migrationBuilder.InsertData(
                table: "Empployees",
                columns: new[] { "Id", "Departement", "Email", "ImageUrl", "Name" },
                values: new object[] { 3, 0, "mohamed@email.com", "/Images/3.jpg", "mohamed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empployees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empployees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empployees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
