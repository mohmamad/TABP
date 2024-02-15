using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_Unigue_From_RoomId_IN_FeaturedDeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturedDeals_Rooms_RoomId",
                table: "FeaturedDeals");

            migrationBuilder.DropIndex(
                name: "IX_FeaturedDeals_RoomId",
                table: "FeaturedDeals");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("2c88aab2-68cc-4b3e-be94-1d864d2782a6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("571ee1ee-158d-42d3-a0d1-29055e50547f"), new DateTime(2024, 2, 4, 5, 38, 38, 279, DateTimeKind.Local).AddTicks(9641), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_FeaturedDeals_RoomId",
                table: "Rooms",
                column: "RoomId",
                principalTable: "FeaturedDeals",
                principalColumn: "FeaturedDealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_FeaturedDeals_RoomId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("571ee1ee-158d-42d3-a0d1-29055e50547f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("2c88aab2-68cc-4b3e-be94-1d864d2782a6"), new DateTime(2024, 2, 4, 5, 11, 49, 555, DateTimeKind.Local).AddTicks(9605), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedDeals_RoomId",
                table: "FeaturedDeals",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedDeals_Rooms_RoomId",
                table: "FeaturedDeals",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }
    }
}
