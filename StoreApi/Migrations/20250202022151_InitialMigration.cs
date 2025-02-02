using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    IdBatch = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.IdBatch);
                    table.ForeignKey(
                        name: "FK_Batches_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "Active", "Description", "Name" },
                values: new object[,]
                {
                    { 1, true, "High performance laptop", "Laptop" },
                    { 2, true, "Latest model smartphone", "Smartphone" },
                    { 3, true, "Noise-cancelling headphones", "Headphones" },
                    { 4, true, "4K Ultra HD monitor", "Monitor" },
                    { 5, true, "Mechanical keyboard", "Keyboard" },
                    { 6, true, "Wireless mouse", "Mouse" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Email", "FechaCreacion", "Name", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "admin@example.com", new DateTime(2025, 2, 1, 21, 21, 50, 705, DateTimeKind.Local).AddTicks(1897), "Admin User", "$2a$11$WyoJRoXjzILZgVrQ2OSrjOfR3zht32cf9q5ICfWlM/7E/StXosuo6" },
                    { 2, "user@example.com", new DateTime(2025, 2, 1, 21, 21, 50, 836, DateTimeKind.Local).AddTicks(79), "Regular User", "$2a$11$KPB3OnNZ5nlN13FIl3.deuxuLFoGKTYGTnbJt3REsjI76Ayfdi5ny" }
                });

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "IdBatch", "Active", "EntryDate", "IdProduct", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 2, 1, 21, 21, 50, 575, DateTimeKind.Local).AddTicks(1650), 1, 1000.00m, 10 },
                    { 2, true, new DateTime(2025, 2, 1, 21, 21, 50, 575, DateTimeKind.Local).AddTicks(1668), 2, 800.00m, 20 },
                    { 3, true, new DateTime(2025, 2, 1, 21, 21, 50, 575, DateTimeKind.Local).AddTicks(1670), 3, 200.00m, 30 },
                    { 4, true, new DateTime(2025, 2, 1, 21, 21, 50, 575, DateTimeKind.Local).AddTicks(1671), 4, 400.00m, 15 },
                    { 5, true, new DateTime(2025, 2, 1, 21, 21, 50, 575, DateTimeKind.Local).AddTicks(1673), 5, 150.00m, 25 },
                    { 6, true, new DateTime(2025, 2, 1, 21, 21, 50, 575, DateTimeKind.Local).AddTicks(1674), 6, 50.00m, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_IdProduct",
                table: "Batches",
                column: "IdProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
