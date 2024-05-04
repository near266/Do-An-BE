using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class enter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enterprises",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    account_id = table.Column<string>(type: "text", nullable: true),
                    abbreviation_name = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: false),
                    phone_verified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    career_field_id = table.Column<int>(type: "integer", nullable: true),
                    website_url = table.Column<string>(type: "text", nullable: true),
                    introduce = table.Column<string>(type: "text", nullable: true),
                    scale_id = table.Column<int>(type: "integer", nullable: true),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    district_id = table.Column<int>(type: "integer", nullable: false),
                    ward_id = table.Column<int>(type: "integer", nullable: true),
                    address = table.Column<string>(type: "text", nullable: false),
                    map_url = table.Column<string>(type: "text", nullable: true),
                    job_post_count = table.Column<int>(type: "integer", nullable: true),
                    business_license_key = table.Column<string>(type: "text", nullable: true),
                    authorization_letter_key = table.Column<string>(type: "text", nullable: true),
                    approve_status_id = table.Column<int>(type: "integer", nullable: false),
                    reason_of_rejection = table.Column<string>(type: "text", nullable: true),
                    receive_news = table.Column<int>(type: "integer", nullable: false),
                    pricing_plan_id = table.Column<string>(type: "text", nullable: true),
                    pricing_plan_start_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    pricing_plan_end_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enterprises", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enterprises");
        }
    }
}
