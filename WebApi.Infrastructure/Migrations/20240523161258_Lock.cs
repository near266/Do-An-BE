using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Lock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Lock",
                table: "userInfos",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                table: "job_post_candidates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsLock",
                table: "enterprises",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lock",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "IsLock",
                table: "enterprises");

            migrationBuilder.AlterColumn<string>(
                name: "status_id",
                table: "job_post_candidates",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
