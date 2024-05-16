using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrMenuBackend.Migrations
{
    /// <inheritdoc />
    public partial class gorupcolumnupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductGroups",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductGroups");
        }
    }
}
