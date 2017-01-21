using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mlp.Blog.Data.Migrations
{
    public partial class AddPgMenuParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PgMenuParentId",
                table: "PgMenu",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PgMenu_PgMenuParentId",
                table: "PgMenu",
                column: "PgMenuParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PgMenu_PgMenu_PgMenuParentId",
                table: "PgMenu",
                column: "PgMenuParentId",
                principalTable: "PgMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PgMenu_PgMenu_PgMenuParentId",
                table: "PgMenu");

            migrationBuilder.DropIndex(
                name: "IX_PgMenu_PgMenuParentId",
                table: "PgMenu");

            migrationBuilder.DropColumn(
                name: "PgMenuParentId",
                table: "PgMenu");
        }
    }
}
