using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooIS.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PassChangeTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequestPasswordReset = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletionRequested = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitats_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PurchaseFinalized = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfUse = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bundles_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    DarkMode = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_RegisteredUsers_Id",
                        column: x => x.Id,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateAquired = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfDeparture = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    HabitatId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Habitats_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "BundleTickets",
                columns: table => new
                {
                    BundleId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleTickets", x => new { x.BundleId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_BundleTickets_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BundleTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "AnimalTagRequire",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTagRequire", x => new { x.AnimalId, x.TagId });
                    table.ForeignKey(
                        name: "FK_AnimalTagRequire_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalTagRequire_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_HabitatId",
                table: "Animals",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTagAvoid_TagId",
                table: "AnimalTagAvoid",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTagRequire_TagId",
                table: "AnimalTagRequire",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_RegisteredUserId",
                table: "Bundles",
                column: "RegisteredUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BundleTickets_TicketId",
                table: "BundleTickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_AreaId",
                table: "Habitats",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitatTag_TagsId",
                table: "HabitatTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalTagAvoid");

            migrationBuilder.DropTable(
                name: "AnimalTagRequire");

            migrationBuilder.DropTable(
                name: "BundleTickets");

            migrationBuilder.DropTable(
                name: "HabitatTag");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "WorkTasks");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
