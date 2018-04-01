using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mvcdemo.Data.Migrations
{
    public partial class NotificationDbSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationApplicationUser_AspNetUsers_ApplicationUserId",
                table: "NotificationApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationApplicationUser_Notification_NotificationId",
                table: "NotificationApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationApplicationUser",
                table: "NotificationApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.RenameTable(
                name: "NotificationApplicationUser",
                newName: "UserNotifications");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationApplicationUser_ApplicationUserId",
                table: "UserNotifications",
                newName: "IX_UserNotifications_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNotifications",
                table: "UserNotifications",
                columns: new[] { "NotificationId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_ApplicationUserId",
                table: "UserNotifications",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_ApplicationUserId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNotifications",
                table: "UserNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "UserNotifications",
                newName: "NotificationApplicationUser");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotifications_ApplicationUserId",
                table: "NotificationApplicationUser",
                newName: "IX_NotificationApplicationUser_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationApplicationUser",
                table: "NotificationApplicationUser",
                columns: new[] { "NotificationId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationApplicationUser_AspNetUsers_ApplicationUserId",
                table: "NotificationApplicationUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationApplicationUser_Notification_NotificationId",
                table: "NotificationApplicationUser",
                column: "NotificationId",
                principalTable: "Notification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
