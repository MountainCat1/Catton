using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conventions.Api.Migrations
{
    /// <inheritdoc />
    public partial class TempMigration_8EYvTOXBQ5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conventions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conventions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AccountUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountAvatarUri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ConventionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizers_Conventions_ConventionId",
                        column: x => x.ConventionId,
                        principalTable: "Conventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Avaliable = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConventionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTemplates_Conventions_ConventionId",
                        column: x => x.ConventionId,
                        principalTable: "Conventions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_ConventionId",
                table: "Organizers",
                column: "ConventionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTemplates_ConventionId",
                table: "TicketTemplates",
                column: "ConventionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "TicketTemplates");

            migrationBuilder.DropTable(
                name: "Conventions");
        }
    }
}
