using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_Unigue_From_RoomId_IN_Featured_Deals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturedDeals_Rooms_RoomId",
                table: "FeaturedDeals");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f3f031e4-3851-47ac-adc2-138aa73ec868"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("d21efa00-2b37-4116-b5cf-34c444215604"), new DateTime(2024, 2, 4, 18, 16, 54, 733, DateTimeKind.Local).AddTicks(2713), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedDeals_Rooms_RoomId",
                table: "FeaturedDeals",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturedDeals_Rooms_RoomId",
                table: "FeaturedDeals");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d21efa00-2b37-4116-b5cf-34c444215604"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("f3f031e4-3851-47ac-adc2-138aa73ec868"), new DateTime(2024, 2, 4, 18, 15, 38, 687, DateTimeKind.Local).AddTicks(6240), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedDeals_Rooms_RoomId",
                table: "FeaturedDeals",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
