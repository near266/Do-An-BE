﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Infrastructure.Persistence;

#nullable disable

namespace WebApi.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerSupportDatabaseContext))]
    [Migration("20240425013631_Fix_Record_Sheet")]
    partial class Fix_Record_Sheet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Domain.Entites.Category", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<List<string>>("Image")
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Customer_TeleSales", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SalesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Customers_TeleSales");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Customers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Customer_TeleSalesId")
                        .HasColumnType("uuid");

                    b.Property<string>("Customer_id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastEngagementDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Taxcode")
                        .HasColumnType("text");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Customer_TeleSalesId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("Image")
                        .HasColumnType("text[]");

                    b.Property<string>("Last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Link_video")
                        .HasColumnType("text");

                    b.Property<string>("Product_description")
                        .HasColumnType("text");

                    b.Property<string>("Product_id")
                        .HasColumnType("text");

                    b.Property<string>("Product_name")
                        .HasColumnType("text");

                    b.Property<double?>("Product_price")
                        .HasColumnType("double precision");

                    b.Property<double?>("Product_sale_price")
                        .HasColumnType("double precision");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title_video")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product_Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Category_id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Product_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("Products_Categories");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.RecordSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TelesaleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RecordSheets");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Record_Relation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CustomersId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RecordId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RecordSheetId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeleSalesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.HasIndex("RecordSheetId");

                    b.HasIndex("TeleSalesId");

                    b.ToTable("Record_Relations");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ExpireAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("IssueAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.TeleSales", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("Customer_TeleSalesId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("Last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Taxcode")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Customer_TeleSalesId");

                    b.ToTable("TeleSales");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Customers", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Customer_TeleSales", null)
                        .WithMany("Customers")
                        .HasForeignKey("Customer_TeleSalesId");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product_Category", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Category", "Category")
                        .WithMany("Product_Categories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("WebApi.Domain.Entites.Product", "Product")
                        .WithMany("Product_Categories")
                        .HasForeignKey("ProductId");

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Record_Relation", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersId");

                    b.HasOne("WebApi.Domain.Entites.RecordSheet", "RecordSheet")
                        .WithMany()
                        .HasForeignKey("RecordSheetId");

                    b.HasOne("WebApi.Domain.Entites.TeleSales", "TeleSales")
                        .WithMany()
                        .HasForeignKey("TeleSalesId");

                    b.Navigation("Customers");

                    b.Navigation("RecordSheet");

                    b.Navigation("TeleSales");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.TeleSales", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Customer_TeleSales", null)
                        .WithMany("TeleSales")
                        .HasForeignKey("Customer_TeleSalesId");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Category", b =>
                {
                    b.Navigation("Product_Categories");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Customer_TeleSales", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("TeleSales");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product", b =>
                {
                    b.Navigation("Product_Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
