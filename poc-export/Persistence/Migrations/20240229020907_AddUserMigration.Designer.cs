﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using poc_export.Persistence;

#nullable disable

namespace poc_export.Persistence.Migrations
{
    [DbContext(typeof(ReportDbContext))]
    [Migration("20240229020907_AddUserMigration")]
    partial class AddUserMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("poc_export.Entities.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created_Date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("poc_export.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birth_Date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb32b50a-9159-447c-bc15-9c14bad0fa95"),
                            BirthDate = new DateTime(2004, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 2, 29, 2, 9, 7, 222, DateTimeKind.Utc).AddTicks(1304),
                            Email = "john@doe",
                            IsDeleted = false,
                            UserName = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("4295884b-364c-4b9d-bd80-d87df920e86c"),
                            BirthDate = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 2, 29, 2, 9, 7, 222, DateTimeKind.Utc).AddTicks(1349),
                            Email = "jane@smith",
                            IsDeleted = false,
                            UserName = "Jane Smith"
                        },
                        new
                        {
                            Id = new Guid("52661dc4-2907-4006-a25c-d36817ab9ffe"),
                            BirthDate = new DateTime(1980, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2024, 2, 29, 2, 9, 7, 222, DateTimeKind.Utc).AddTicks(1351),
                            Email = "alice@johnson",
                            IsDeleted = false,
                            UserName = "Alice Johnson"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}