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
    [Migration("20240418170753_record")]
    partial class record
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
                    b.Property<Guid?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<List<string>>("image")
                        .HasColumnType("text[]");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

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
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Customer_TeleSalesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("customer_id")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<int?>("gender")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("lastEngagementDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("note")
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("status")
                        .HasColumnType("integer");

                    b.Property<string>("taxcode")
                        .HasColumnType("text");

                    b.Property<int?>("type")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Customer_TeleSalesId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("image")
                        .HasColumnType("text[]");

                    b.Property<string>("last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("link_video")
                        .HasColumnType("text");

                    b.Property<string>("product_description")
                        .HasColumnType("text");

                    b.Property<string>("product_id")
                        .HasColumnType("text");

                    b.Property<string>("product_name")
                        .HasColumnType("text");

                    b.Property<double?>("product_price")
                        .HasColumnType("double precision");

                    b.Property<double?>("product_sale_price")
                        .HasColumnType("double precision");

                    b.Property<int?>("status")
                        .HasColumnType("integer");

                    b.Property<string>("title_video")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product_Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Categoryid")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Productid")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("category_id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("product_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Categoryid");

                    b.HasIndex("Productid");

                    b.ToTable("Products_Categories");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.TeleSales", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Customer_TeleSalesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<int?>("gender")
                        .HasColumnType("integer");

                    b.Property<string>("last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("note")
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("status")
                        .HasColumnType("integer");

                    b.Property<string>("taxcode")
                        .HasColumnType("text");

                    b.Property<string>("userId")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Customer_TeleSalesId");

                    b.ToTable("teleSales");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.recordSheet", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("last_modified_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("last_modified_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("priority")
                        .HasColumnType("integer");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("recordSheets");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.record_Relation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Customersid")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RecordSheetid")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeleSalesid")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("recordId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Customersid");

                    b.HasIndex("RecordSheetid");

                    b.HasIndex("TeleSalesid");

                    b.ToTable("record_Relations");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Customers", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Customer_TeleSales", null)
                        .WithMany("customers")
                        .HasForeignKey("Customer_TeleSalesId");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product_Category", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Category", "Category")
                        .WithMany("Product_Categories")
                        .HasForeignKey("Categoryid");

                    b.HasOne("WebApi.Domain.Entites.Product", "Product")
                        .WithMany("Product_Categories")
                        .HasForeignKey("Productid");

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.TeleSales", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Customer_TeleSales", null)
                        .WithMany("teleSales")
                        .HasForeignKey("Customer_TeleSalesId");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.record_Relation", b =>
                {
                    b.HasOne("WebApi.Domain.Entites.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("Customersid");

                    b.HasOne("WebApi.Domain.Entites.recordSheet", "RecordSheet")
                        .WithMany()
                        .HasForeignKey("RecordSheetid");

                    b.HasOne("WebApi.Domain.Entites.TeleSales", "TeleSales")
                        .WithMany()
                        .HasForeignKey("TeleSalesid");

                    b.Navigation("Customers");

                    b.Navigation("RecordSheet");

                    b.Navigation("TeleSales");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Category", b =>
                {
                    b.Navigation("Product_Categories");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Customer_TeleSales", b =>
                {
                    b.Navigation("customers");

                    b.Navigation("teleSales");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Product", b =>
                {
                    b.Navigation("Product_Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
