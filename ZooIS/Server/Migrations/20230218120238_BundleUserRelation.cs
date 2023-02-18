using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooIS.Server.Migrations
{
    /// <inheritdoc />
    public partial class BundleUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_Area_AreaId",
                table: "Habitats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Area",
                table: "Area");

            migrationBuilder.RenameTable(
                name: "Area",
                newName: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "RegisteredUserId",
                table: "Bundles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Areas",
                table: "Areas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_RegisteredUserId",
                table: "Bundles",
                column: "RegisteredUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bundles_RegisteredUsers_RegisteredUserId",
                table: "Bundles",
                column: "RegisteredUserId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_Areas_AreaId",
                table: "Habitats",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bundles_RegisteredUsers_RegisteredUserId",
                table: "Bundles");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_Areas_AreaId",
                table: "Habitats");

            migrationBuilder.DropIndex(
                name: "IX_Bundles_RegisteredUserId",
                table: "Bundles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Areas",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "RegisteredUserId",
                table: "Bundles");

            migrationBuilder.RenameTable(
                name: "Areas",
                newName: "Area");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Area",
                table: "Area",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_Area_AreaId",
                table: "Habitats",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
