using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateuser65 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "userInfos",
                newName: "address");

            migrationBuilder.AddColumn<string>(
                name: "information",
                table: "userInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telephone",
                table: "userInfos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "information",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "telephone",
                table: "userInfos");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "userInfos",
                newName: "Address");
        }
    }
}
