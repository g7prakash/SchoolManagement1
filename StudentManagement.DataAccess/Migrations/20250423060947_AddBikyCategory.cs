using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBikyCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_bikes_tbl_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "tbl_brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bike_categories",
                columns: table => new
                {
                    BikeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bike_categories", x => new { x.BikeId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_tbl_bike_categories_tbl_bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "tbl_bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_bike_categories_tbl_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tbl_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bike_categories_CategoryId",
                table: "tbl_bike_categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bikes_BrandId",
                table: "tbl_bikes",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_bike_categories");

            migrationBuilder.DropTable(
                name: "tbl_bikes");

            migrationBuilder.DropTable(
                name: "tbl_categories");

            migrationBuilder.DropTable(
                name: "tbl_brands");
        }
    }
}
