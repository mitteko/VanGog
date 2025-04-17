using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanGog.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Events",
                newSchema: "public");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                schema: "public",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Events",
                schema: "public",
                newName: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Events",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
