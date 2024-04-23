using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Col_Name_And_Add_RF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Categories_Categoryid",
                table: "Products_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Products_Productid",
                table: "Products_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_record_Relations_Customers_Customersid",
                table: "record_Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_record_Relations_recordSheets_RecordSheetid",
                table: "record_Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_record_Relations_teleSales_TeleSalesid",
                table: "record_Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_teleSales_Customers_TeleSales_Customer_TeleSalesId",
                table: "teleSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teleSales",
                table: "teleSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_record_Relations",
                table: "record_Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recordSheets",
                table: "recordSheets");

            migrationBuilder.RenameTable(
                name: "teleSales",
                newName: "TeleSales");

            migrationBuilder.RenameTable(
                name: "record_Relations",
                newName: "Record_Relations");

            migrationBuilder.RenameTable(
                name: "recordSheets",
                newName: "RecordSheets");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "TeleSales",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "taxcode",
                table: "TeleSales",
                newName: "Taxcode");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "TeleSales",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "TeleSales",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "TeleSales",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TeleSales",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "last_modified_date",
                table: "TeleSales",
                newName: "Last_modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modified_by",
                table: "TeleSales",
                newName: "Last_modified_by");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "TeleSales",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "TeleSales",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "TeleSales",
                newName: "Created_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "TeleSales",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "TeleSales",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TeleSales",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_teleSales_Customer_TeleSalesId",
                table: "TeleSales",
                newName: "IX_TeleSales_Customer_TeleSalesId");

            migrationBuilder.RenameColumn(
                name: "recordId",
                table: "Record_Relations",
                newName: "RecordId");

            migrationBuilder.RenameColumn(
                name: "TeleSalesid",
                table: "Record_Relations",
                newName: "TeleSalesId");

            migrationBuilder.RenameColumn(
                name: "RecordSheetid",
                table: "Record_Relations",
                newName: "RecordSheetId");

            migrationBuilder.RenameColumn(
                name: "Customersid",
                table: "Record_Relations",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_record_Relations_TeleSalesid",
                table: "Record_Relations",
                newName: "IX_Record_Relations_TeleSalesId");

            migrationBuilder.RenameIndex(
                name: "IX_record_Relations_RecordSheetid",
                table: "Record_Relations",
                newName: "IX_Record_Relations_RecordSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_record_Relations_Customersid",
                table: "Record_Relations",
                newName: "IX_Record_Relations_CustomersId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "RecordSheets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "RecordSheets",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "RecordSheets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "last_modified_date",
                table: "RecordSheets",
                newName: "Last_modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modified_by",
                table: "RecordSheets",
                newName: "Last_modified_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "RecordSheets",
                newName: "Created_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "RecordSheets",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RecordSheets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Products_Categories",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Products_Categories",
                newName: "Category_id");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "Products_Categories",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Categoryid",
                table: "Products_Categories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Categories_Productid",
                table: "Products_Categories",
                newName: "IX_Products_Categories_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Categories_Categoryid",
                table: "Products_Categories",
                newName: "IX_Products_Categories_CategoryId");

            migrationBuilder.RenameColumn(
                name: "title_video",
                table: "Products",
                newName: "Title_video");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Products",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "product_sale_price",
                table: "Products",
                newName: "Product_sale_price");

            migrationBuilder.RenameColumn(
                name: "product_price",
                table: "Products",
                newName: "Product_price");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Products",
                newName: "Product_name");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Products",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "product_description",
                table: "Products",
                newName: "Product_description");

            migrationBuilder.RenameColumn(
                name: "link_video",
                table: "Products",
                newName: "Link_video");

            migrationBuilder.RenameColumn(
                name: "last_modified_date",
                table: "Products",
                newName: "Last_modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modified_by",
                table: "Products",
                newName: "Last_modified_by");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Products",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Products",
                newName: "Created_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "Products",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Customers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "taxcode",
                table: "Customers",
                newName: "Taxcode");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Customers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "Customers",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "last_modified_date",
                table: "Customers",
                newName: "Last_modified_date");

            migrationBuilder.RenameColumn(
                name: "last_modified_by",
                table: "Customers",
                newName: "Last_modified_by");

            migrationBuilder.RenameColumn(
                name: "lastEngagementDate",
                table: "Customers",
                newName: "LastEngagementDate");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Customers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "Customers",
                newName: "Customer_id");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Customers",
                newName: "Created_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "Customers",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "Customers",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Categories",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Categories",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeleSales",
                table: "TeleSales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Record_Relations",
                table: "Record_Relations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordSheets",
                table: "RecordSheets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    IssueAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Categories_CategoryId",
                table: "Products_Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Products_ProductId",
                table: "Products_Categories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Relations_Customers_CustomersId",
                table: "Record_Relations",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Relations_RecordSheets_RecordSheetId",
                table: "Record_Relations",
                column: "RecordSheetId",
                principalTable: "RecordSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Relations_TeleSales_TeleSalesId",
                table: "Record_Relations",
                column: "TeleSalesId",
                principalTable: "TeleSales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeleSales_Customers_TeleSales_Customer_TeleSalesId",
                table: "TeleSales",
                column: "Customer_TeleSalesId",
                principalTable: "Customers_TeleSales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Categories_CategoryId",
                table: "Products_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Products_ProductId",
                table: "Products_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Relations_Customers_CustomersId",
                table: "Record_Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Relations_RecordSheets_RecordSheetId",
                table: "Record_Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Relations_TeleSales_TeleSalesId",
                table: "Record_Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeleSales_Customers_TeleSales_Customer_TeleSalesId",
                table: "TeleSales");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeleSales",
                table: "TeleSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Record_Relations",
                table: "Record_Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordSheets",
                table: "RecordSheets");

            migrationBuilder.RenameTable(
                name: "TeleSales",
                newName: "teleSales");

            migrationBuilder.RenameTable(
                name: "Record_Relations",
                newName: "record_Relations");

            migrationBuilder.RenameTable(
                name: "RecordSheets",
                newName: "recordSheets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "teleSales",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Taxcode",
                table: "teleSales",
                newName: "taxcode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "teleSales",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "teleSales",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "teleSales",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "teleSales",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Last_modified_date",
                table: "teleSales",
                newName: "last_modified_date");

            migrationBuilder.RenameColumn(
                name: "Last_modified_by",
                table: "teleSales",
                newName: "last_modified_by");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "teleSales",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "teleSales",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Created_date",
                table: "teleSales",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "teleSales",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "teleSales",
                newName: "birthday");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "teleSales",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TeleSales_Customer_TeleSalesId",
                table: "teleSales",
                newName: "IX_teleSales_Customer_TeleSalesId");

            migrationBuilder.RenameColumn(
                name: "TeleSalesId",
                table: "record_Relations",
                newName: "TeleSalesid");

            migrationBuilder.RenameColumn(
                name: "RecordSheetId",
                table: "record_Relations",
                newName: "RecordSheetid");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "record_Relations",
                newName: "recordId");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "record_Relations",
                newName: "Customersid");

            migrationBuilder.RenameIndex(
                name: "IX_Record_Relations_TeleSalesId",
                table: "record_Relations",
                newName: "IX_record_Relations_TeleSalesid");

            migrationBuilder.RenameIndex(
                name: "IX_Record_Relations_RecordSheetId",
                table: "record_Relations",
                newName: "IX_record_Relations_RecordSheetid");

            migrationBuilder.RenameIndex(
                name: "IX_Record_Relations_CustomersId",
                table: "record_Relations",
                newName: "IX_record_Relations_Customersid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "recordSheets",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "recordSheets",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "recordSheets",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Last_modified_date",
                table: "recordSheets",
                newName: "last_modified_date");

            migrationBuilder.RenameColumn(
                name: "Last_modified_by",
                table: "recordSheets",
                newName: "last_modified_by");

            migrationBuilder.RenameColumn(
                name: "Created_date",
                table: "recordSheets",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "recordSheets",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "recordSheets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "Products_Categories",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products_Categories",
                newName: "Productid");

            migrationBuilder.RenameColumn(
                name: "Category_id",
                table: "Products_Categories",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products_Categories",
                newName: "Categoryid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Categories_ProductId",
                table: "Products_Categories",
                newName: "IX_Products_Categories_Productid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Categories_CategoryId",
                table: "Products_Categories",
                newName: "IX_Products_Categories_Categoryid");

            migrationBuilder.RenameColumn(
                name: "Title_video",
                table: "Products",
                newName: "title_video");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Products",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Product_sale_price",
                table: "Products",
                newName: "product_sale_price");

            migrationBuilder.RenameColumn(
                name: "Product_price",
                table: "Products",
                newName: "product_price");

            migrationBuilder.RenameColumn(
                name: "Product_name",
                table: "Products",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "Products",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "Product_description",
                table: "Products",
                newName: "product_description");

            migrationBuilder.RenameColumn(
                name: "Link_video",
                table: "Products",
                newName: "link_video");

            migrationBuilder.RenameColumn(
                name: "Last_modified_date",
                table: "Products",
                newName: "last_modified_date");

            migrationBuilder.RenameColumn(
                name: "Last_modified_by",
                table: "Products",
                newName: "last_modified_by");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Created_date",
                table: "Products",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "Products",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Customers",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Taxcode",
                table: "Customers",
                newName: "taxcode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Customers",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Customers",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Last_modified_date",
                table: "Customers",
                newName: "last_modified_date");

            migrationBuilder.RenameColumn(
                name: "Last_modified_by",
                table: "Customers",
                newName: "last_modified_by");

            migrationBuilder.RenameColumn(
                name: "LastEngagementDate",
                table: "Customers",
                newName: "lastEngagementDate");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Customers",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Customer_id",
                table: "Customers",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "Created_date",
                table: "Customers",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "Customers",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Customers",
                newName: "birthday");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Categories",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teleSales",
                table: "teleSales",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_record_Relations",
                table: "record_Relations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recordSheets",
                table: "recordSheets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Categories_Categoryid",
                table: "Products_Categories",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Products_Productid",
                table: "Products_Categories",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_Relations_Customers_Customersid",
                table: "record_Relations",
                column: "Customersid",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_Relations_recordSheets_RecordSheetid",
                table: "record_Relations",
                column: "RecordSheetid",
                principalTable: "recordSheets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_record_Relations_teleSales_TeleSalesid",
                table: "record_Relations",
                column: "TeleSalesid",
                principalTable: "teleSales",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_teleSales_Customers_TeleSales_Customer_TeleSalesId",
                table: "teleSales",
                column: "Customer_TeleSalesId",
                principalTable: "Customers_TeleSales",
                principalColumn: "Id");
        }
    }
}
