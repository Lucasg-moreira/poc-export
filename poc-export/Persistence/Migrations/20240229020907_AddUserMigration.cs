using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace poc_export.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Birth_Date", "Created_at", "Email", "IsDeleted", "UserName" },
                values: new object[,]
                {
                    { new Guid("4295884b-364c-4b9d-bd80-d87df920e86c"), new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 2, 9, 7, 222, DateTimeKind.Utc).AddTicks(1349), "jane@smith", false, "Jane Smith" },
                    { new Guid("52661dc4-2907-4006-a25c-d36817ab9ffe"), new DateTime(1980, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 2, 9, 7, 222, DateTimeKind.Utc).AddTicks(1351), "alice@johnson", false, "Alice Johnson" },
                    { new Guid("fb32b50a-9159-447c-bc15-9c14bad0fa95"), new DateTime(2004, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 2, 9, 7, 222, DateTimeKind.Utc).AddTicks(1304), "john@doe", false, "John Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
