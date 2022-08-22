using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Infrastructure.Migrations
{
    public partial class AddGameDeveloperRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDeveloper_Developers_DeveloperId",
                table: "GameDeveloper");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDeveloper_Games_GameId",
                table: "GameDeveloper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDeveloper",
                table: "GameDeveloper");

            migrationBuilder.RenameTable(
                name: "GameDeveloper",
                newName: "GameDevelopers");

            migrationBuilder.RenameIndex(
                name: "IX_GameDeveloper_GameId",
                table: "GameDevelopers",
                newName: "IX_GameDevelopers_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDevelopers",
                table: "GameDevelopers",
                columns: new[] { "DeveloperId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevelopers_Developers_DeveloperId",
                table: "GameDevelopers",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevelopers_Games_GameId",
                table: "GameDevelopers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevelopers_Developers_DeveloperId",
                table: "GameDevelopers");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDevelopers_Games_GameId",
                table: "GameDevelopers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDevelopers",
                table: "GameDevelopers");

            migrationBuilder.RenameTable(
                name: "GameDevelopers",
                newName: "GameDeveloper");

            migrationBuilder.RenameIndex(
                name: "IX_GameDevelopers_GameId",
                table: "GameDeveloper",
                newName: "IX_GameDeveloper_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDeveloper",
                table: "GameDeveloper",
                columns: new[] { "DeveloperId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameDeveloper_Developers_DeveloperId",
                table: "GameDeveloper",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDeveloper_Games_GameId",
                table: "GameDeveloper",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
