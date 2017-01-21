using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mlp.Blog.Data.Migrations
{
    public partial class PgMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PgTypeMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PgTypeMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PgMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    FaIcon = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Tooltip = table.Column<string>(nullable: true),
                    TypeMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PgMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PgMenu_PgTypeMenu_TypeMenuId",
                        column: x => x.TypeMenuId,
                        principalTable: "PgTypeMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PgMenu_TypeMenuId",
                table: "PgMenu",
                column: "TypeMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PgMenu");

            migrationBuilder.DropTable(
                name: "PgTypeMenu");
        }
    }
}
