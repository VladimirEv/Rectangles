using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rectangles.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorBodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorBodyValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorBodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorLineValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XValue = table.Column<double>(type: "float", nullable: false),
                    YValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberRectangle = table.Column<int>(type: "int", nullable: false),
                    NameRectangle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BotLeftId = table.Column<int>(type: "int", nullable: false),
                    TopRightId = table.Column<int>(type: "int", nullable: false),
                    ColorBodyRectangleId = table.Column<int>(type: "int", nullable: false),
                    ColorLineRectangleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectangles_ColorBodies_ColorBodyRectangleId",
                        column: x => x.ColorBodyRectangleId,
                        principalTable: "ColorBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rectangles_ColorLines_ColorLineRectangleId",
                        column: x => x.ColorLineRectangleId,
                        principalTable: "ColorLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rectangles_Points_BotLeftId",
                        column: x => x.BotLeftId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rectangles_Points_TopRightId",
                        column: x => x.TopRightId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_BotLeftId",
                table: "Rectangles",
                column: "BotLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_ColorBodyRectangleId",
                table: "Rectangles",
                column: "ColorBodyRectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_ColorLineRectangleId",
                table: "Rectangles",
                column: "ColorLineRectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_TopRightId",
                table: "Rectangles",
                column: "TopRightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rectangles");

            migrationBuilder.DropTable(
                name: "ColorBodies");

            migrationBuilder.DropTable(
                name: "ColorLines");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
