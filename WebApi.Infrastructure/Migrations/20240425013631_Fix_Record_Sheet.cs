using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Record_Sheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RecordSheets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "RecordSheets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "RecordSheets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelesaleId",
                table: "RecordSheets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "RecordSheets");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "RecordSheets");

            migrationBuilder.DropColumn(
                name: "TelesaleId",
                table: "RecordSheets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RecordSheets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
