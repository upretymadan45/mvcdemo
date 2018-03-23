using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mvcdemo.Data.Migrations
{
    public partial class Watchlists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlist_Pets_PetId",
                table: "Watchlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId",
                table: "Watchlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watchlist",
                table: "Watchlist");

            migrationBuilder.RenameTable(
                name: "Watchlist",
                newName: "Watchlists");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlist_UserId",
                table: "Watchlists",
                newName: "IX_Watchlists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlist_PetId",
                table: "Watchlists",
                newName: "IX_Watchlists_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_Pets_PetId",
                table: "Watchlists",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId",
                table: "Watchlists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_Pets_PetId",
                table: "Watchlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId",
                table: "Watchlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlists");

            migrationBuilder.RenameTable(
                name: "Watchlists",
                newName: "Watchlist");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlist",
                newName: "IX_Watchlist_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlists_PetId",
                table: "Watchlist",
                newName: "IX_Watchlist_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watchlist",
                table: "Watchlist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlist_Pets_PetId",
                table: "Watchlist",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId",
                table: "Watchlist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
