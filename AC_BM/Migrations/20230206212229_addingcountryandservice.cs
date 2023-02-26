  using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACBM.Migrations
{
    /// <inheritdoc />
    public partial class addingcountryandservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "Client");
        }
    }
}
