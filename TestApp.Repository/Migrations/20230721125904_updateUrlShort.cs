using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Repository.Migrations
{
    public partial class updateUrlShort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlKey",
                table: "UrlShorts",
                newName: "ShortUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortUrl",
                table: "UrlShorts",
                newName: "UrlKey");
        }
    }
}
