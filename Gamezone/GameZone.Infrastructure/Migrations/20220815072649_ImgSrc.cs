using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Infrastructure.Migrations
{
    public partial class ImgSrc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Games");
        }
    }
}
