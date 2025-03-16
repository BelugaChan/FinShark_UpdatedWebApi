using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FinShark");

            migrationBuilder.CreateTable(
                name: "Stock",
                schema: "FinShark",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    symbol = table.Column<string>(type: "text", nullable: false),
                    companyName = table.Column<string>(type: "text", nullable: false),
                    purchase = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    lastDiv = table.Column<decimal>(type: "numeric", nullable: false),
                    industry = table.Column<string>(type: "text", nullable: false),
                    marketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "FinShark",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    createdOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    stockId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_Stock",
                        column: x => x.stockId,
                        principalSchema: "FinShark",
                        principalTable: "Stock",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_stockId",
                schema: "FinShark",
                table: "Comment",
                column: "stockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment",
                schema: "FinShark");

            migrationBuilder.DropTable(
                name: "Stock",
                schema: "FinShark");
        }
    }
}
