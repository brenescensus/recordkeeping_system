using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACBM.Migrations
{
    /// <inheritdoc />
    public partial class updatingtableservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceImage",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceImage",
                table: "Services");
        }
    }
}
