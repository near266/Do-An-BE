using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateUser2345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telephone",
                table: "userInfos",
                newName: "ward_id");

            migrationBuilder.AddColumn<string>(
                name: "city_id",
                table: "userInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "district_id",
                table: "userInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gender_id",
                table: "userInfos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "userInfos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city_id",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "district_id",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "gender_id",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "userInfos");

            migrationBuilder.RenameColumn(
                name: "ward_id",
                table: "userInfos",
                newName: "telephone");
        }
    }
}
