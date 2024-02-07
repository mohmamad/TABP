using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_Unigue_From_RoomId_IN_FeaturedDea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_FeaturedDeals_RoomId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("571ee1ee-158d-42d3-a0d1-29055e50547f"));

            migrationBuilder.AddColumn<Guid>(
                name: "FeaturedDealId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("5db7a835-9f5d-4f32-a730-bdb939d70ecc"), new DateTime(2024, 2, 4, 6, 27, 53, 657, DateTimeKind.Local).AddTicks(454), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FeaturedDealId",
                table: "Rooms",
                column: "FeaturedDealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_FeaturedDeals_FeaturedDealId",
                table: "Rooms",
                column: "FeaturedDealId",
                principalTable: "FeaturedDeals",
                principalColumn: "FeaturedDealId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_FeaturedDeals_FeaturedDealId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FeaturedDealId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("5db7a835-9f5d-4f32-a730-bdb939d70ecc"));

            migrationBuilder.DropColumn(
                name: "FeaturedDealId",
                table: "Rooms");

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
    }
}
