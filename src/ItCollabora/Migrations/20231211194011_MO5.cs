using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItCollabora.Migrations
{
    /// <inheritdoc />
    public partial class MO5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_User_OwnerUserId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_OwnerUserId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Room",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserModelUserId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_UserModelUserId",
                table: "Room",
                column: "UserModelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_User_UserModelUserId",
                table: "Room",
                column: "UserModelUserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_User_UserModelUserId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_UserModelUserId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "UserModelUserId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Room",
                newName: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_OwnerUserId",
                table: "Room",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_User_OwnerUserId",
                table: "Room",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
