using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooIS.Server.Migrations
{
    /// <inheritdoc />
    public partial class AreaHabitatRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Habitats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_AreaId",
                table: "Habitats",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_Area_AreaId",
                table: "Habitats",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_Area_AreaId",
                table: "Habitats");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Habitats_AreaId",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Habitats");
        }
    }
}
