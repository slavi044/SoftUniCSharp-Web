using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstMvcApp.Migrations
{
    public partial class InitialCreateDesing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCards",
                table: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_UserCards_UserId",
                table: "UserCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCards",
                table: "UserCards",
                columns: new[] { "UserId", "CardId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_CardId",
                table: "UserCards",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCards",
                table: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_UserCards_CardId",
                table: "UserCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCards",
                table: "UserCards",
                columns: new[] { "CardId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_UserId",
                table: "UserCards",
                column: "UserId");
        }
    }
}
