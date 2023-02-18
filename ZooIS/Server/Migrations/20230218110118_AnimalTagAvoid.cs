using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooIS.Server.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTagAvoid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTagAvoid",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTagAvoid", x => new { x.AnimalId, x.TagId });
                    table.ForeignKey(
                        name: "FK_AnimalTagAvoid_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalTagAvoid_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTagAvoid_TagId",
                table: "AnimalTagAvoid",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalTagAvoid");
        }
    }
}
