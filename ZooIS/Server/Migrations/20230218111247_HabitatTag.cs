using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooIS.Server.Migrations
{
    /// <inheritdoc />
    public partial class HabitatTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabitatTag",
                columns: table => new
                {
                    HabitatsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitatTag", x => new { x.HabitatsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_HabitatTag_Habitats_HabitatsId",
                        column: x => x.HabitatsId,
                        principalTable: "Habitats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitatTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitatTag_TagsId",
                table: "HabitatTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitatTag");

            migrationBuilder.DropTable(
                name: "Habitats");
        }
    }
}
