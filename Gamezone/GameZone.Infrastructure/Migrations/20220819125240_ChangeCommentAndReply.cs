using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Infrastructure.Migrations
{
    public partial class ChangeCommentAndReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Username",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Games_Name",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameDetails", "ImageSrc", "Name", "ReleaseDate", "TotalRating" },
                values: new object[] { new Guid("dfc8f3f8-9d1a-49b7-8c5a-cddbde8f0af2"), null, null, "Game 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { new Guid("8caa7fcd-41ce-4252-8ec2-2fffde755780"), "user2@test.com", "First name 2", "Last name 2", null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { new Guid("95e85692-3721-4bf9-9966-edab69ff81d5"), "user1@test.com", "First name 1", "Last name 1", null, null, null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "GameId", "UserId" },
                values: new object[] { new Guid("7bf0dc94-f67d-4ea9-b6f6-048eb66b7ac8"), "Content 1", new Guid("dfc8f3f8-9d1a-49b7-8c5a-cddbde8f0af2"), new Guid("95e85692-3721-4bf9-9966-edab69ff81d5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "GameId", "UserId" },
                values: new object[] { new Guid("bf089e47-fc78-4592-9a49-33330ff0ab2c"), "Content 2", new Guid("dfc8f3f8-9d1a-49b7-8c5a-cddbde8f0af2"), new Guid("95e85692-3721-4bf9-9966-edab69ff81d5") });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "CommentId", "Content", "UserId" },
                values: new object[] { new Guid("982d4b3a-0880-4984-9f23-a202e57c9eb5"), new Guid("7bf0dc94-f67d-4ea9-b6f6-048eb66b7ac8"), "Reply content 1", new Guid("8caa7fcd-41ce-4252-8ec2-2fffde755780") });

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("bf089e47-fc78-4592-9a49-33330ff0ab2c"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("982d4b3a-0880-4984-9f23-a202e57c9eb5"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7bf0dc94-f67d-4ea9-b6f6-048eb66b7ac8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8caa7fcd-41ce-4252-8ec2-2fffde755780"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("dfc8f3f8-9d1a-49b7-8c5a-cddbde8f0af2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95e85692-3721-4bf9-9966-edab69ff81d5"));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Username",
                table: "Users",
                column: "Username");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Games_Name",
                table: "Games",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
