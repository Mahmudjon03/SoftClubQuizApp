using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTest_Groups_GroupId",
                table: "StudentTest");

            migrationBuilder.DropIndex(
                name: "IX_StudentTest_GroupId",
                table: "StudentTest");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "StudentTest");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Answers",
                newName: "IsCorrect");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "Answers",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "StudentTest",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_GroupId",
                table: "StudentTest",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTest_Groups_GroupId",
                table: "StudentTest",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
