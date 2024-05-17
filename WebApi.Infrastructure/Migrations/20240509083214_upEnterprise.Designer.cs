﻿// <auto-generated />
using System;
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
    [Migration("20240509083214_upEnterprise")]
    partial class upEnterprise
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Domain.Entites.Account.enterprises", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("abbreviation_name")
                        .HasColumnType("text");

                    b.Property<string>("account_id")
                        .HasColumnType("text");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("approve_status_id")
                        .HasColumnType("integer");

                    b.Property<string>("authorization_letter_key")
                        .HasColumnType("text");

                    b.Property<string>("business_license_key")
                        .HasColumnType("text");

                    b.Property<int?>("career_field_id")
                        .HasColumnType("integer");

                    b.Property<string>("city_id")
                        .HasColumnType("text");

                    b.Property<string>("companyName")
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("district_id")
                        .HasColumnType("text");

                    b.Property<int?>("genger")
                        .HasColumnType("integer");

                    b.Property<string>("introduce")
                        .HasColumnType("text");

                    b.Property<int?>("job_post_count")
                        .HasColumnType("integer");

                    b.Property<string>("map_url")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("phone_verified_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("pricing_plan_end_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("pricing_plan_id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("pricing_plan_start_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("reason_of_rejection")
                        .HasColumnType("text");

                    b.Property<int>("receive_news")
                        .HasColumnType("integer");

                    b.Property<int?>("scale_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("update_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("update_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ward_id")
                        .HasColumnType("text");

                    b.Property<string>("website_url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("enterprises");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Account.userInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Account_id")
                        .HasColumnType("text");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("avatar")
                        .HasColumnType("text");

                    b.Property<string>("birthday")
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("information")
                        .HasColumnType("text");

                    b.Property<string>("telephone")
                        .HasColumnType("text");

                    b.Property<DateTime?>("update_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("update_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("userInfos");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Assesment.Assessment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<int?>("assessment_type")
                        .HasColumnType("integer");

                    b.Property<string>("avatar")
                        .HasColumnType("text");

                    b.Property<string>("columns")
                        .HasColumnType("text");

                    b.Property<string>("content")
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("original_price")
                        .HasColumnType("integer");

                    b.Property<int?>("sale_code")
                        .HasColumnType("integer");

                    b.Property<string>("slug")
                        .HasColumnType("text");

                    b.Property<int?>("status")
                        .HasColumnType("integer");

                    b.Property<int?>("test_time")
                        .HasColumnType("integer");

                    b.Property<string>("test_tutorial")
                        .HasColumnType("text");

                    b.Property<int?>("type_code")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("update_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("update_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("assessments");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Assesment.assessment_questions", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("assessment_id")
                        .HasColumnType("text");

                    b.Property<string>("columns")
                        .HasColumnType("text");

                    b.Property<string>("content")
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("question_type")
                        .HasColumnType("text");

                    b.Property<DateTime?>("update_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("update_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("assessment_Questions");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Assesment.assessment_test_results", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("assessment_id")
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("result")
                        .HasColumnType("text");

                    b.Property<int?>("suggestion_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("update_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("update_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("user_id")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Assessment_Test_Results");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Job.Event", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("adrress")
                        .HasColumnType("text");

                    b.Property<string>("author")
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("img")
                        .HasColumnType("text");

                    b.Property<int?>("priority")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("update_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("update_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("events");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Job.job_post_candidates", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("id"));

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("cv_path")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<int?>("job_post_id")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("status_id")
                        .HasColumnType("text");

                    b.Property<int?>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("job_post_candidates");
                });

            modelBuilder.Entity("WebApi.Domain.Entites.Job.job_posts", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("approve_status_id")
                        .HasColumnType("text");

                    b.Property<string>("benefit")
                        .HasColumnType("text");

                    b.Property<int>("career_field_id")
                        .HasColumnType("integer");

                    b.Property<string>("career_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<string>("contact_email")
                        .HasColumnType("text");

                    b.Property<string>("contact_name")
                        .HasColumnType("text");

                    b.Property<string>("contact_phone")
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("diploma")
                        .HasColumnType("text");

                    b.Property<string>("district")
                        .HasColumnType("text");

                    b.Property<int>("enterprise_id")
                        .HasColumnType("integer");

                    b.Property<string>("experience")
                        .HasColumnType("text");

                    b.Property<string>("form_of_work")
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .HasColumnType("text");

                    b.Property<string>("image_url")
                        .HasColumnType("text");

                    b.Property<string>("level")
                        .HasColumnType("text");

                    b.Property<string>("map_url")
                        .HasColumnType("text");

                    b.Property<string>("overview")
                        .HasColumnType("text");

                    b.Property<string>("probationary_period")
                        .HasColumnType("text");

                    b.Property<string>("reason_of_view")
                        .HasColumnType("text");

                    b.Property<string>("requirement")
                        .HasColumnType("text");

                    b.Property<int?>("salary_max")
                        .HasColumnType("integer");

                    b.Property<int?>("salary_min")
                        .HasColumnType("integer");

                    b.Property<string>("salary_type")
                        .HasColumnType("text");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("status_id")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("total_cv")
                        .HasColumnType("integer");

                    b.Property<int?>("total_view")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("update_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("update_by")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("job_Posts");
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
#pragma warning restore 612, 618
        }
    }
}
