using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class upEnterprise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyName",
                table: "enterprises",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genger",
                table: "enterprises",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyName",
                table: "enterprises");

            migrationBuilder.DropColumn(
                name: "genger",
                table: "enterprises");
        }
    }
}
