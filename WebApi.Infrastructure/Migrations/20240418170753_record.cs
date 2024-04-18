using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class record : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "recordSheets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordSheets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "record_Relations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    recordId = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    RecordSheetid = table.Column<Guid>(type: "uuid", nullable: true),
                    Customersid = table.Column<Guid>(type: "uuid", nullable: true),
                    TeleSalesid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_record_Relations_Customers_Customersid",
                        column: x => x.Customersid,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_record_Relations_recordSheets_RecordSheetid",
                        column: x => x.RecordSheetid,
                        principalTable: "recordSheets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_record_Relations_teleSales_TeleSalesid",
                        column: x => x.TeleSalesid,
                        principalTable: "teleSales",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_record_Relations_Customersid",
                table: "record_Relations",
                column: "Customersid");

            migrationBuilder.CreateIndex(
                name: "IX_record_Relations_RecordSheetid",
                table: "record_Relations",
                column: "RecordSheetid");

            migrationBuilder.CreateIndex(
                name: "IX_record_Relations_TeleSalesid",
                table: "record_Relations",
                column: "TeleSalesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "record_Relations");

            migrationBuilder.DropTable(
                name: "recordSheets");
        }
    }
}
