using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooIS.Server.Migrations
{
    /// <inheritdoc />
    public partial class AnimalHabitatRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HabitatId",
                table: "Animals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_HabitatId",
                table: "Animals",
                column: "HabitatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Habitats_HabitatId",
                table: "Animals",
                column: "HabitatId",
                principalTable: "Habitats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Habitats_HabitatId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_HabitatId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "HabitatId",
                table: "Animals");
        }
    }
}
