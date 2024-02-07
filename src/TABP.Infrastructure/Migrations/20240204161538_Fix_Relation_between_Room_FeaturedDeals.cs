using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Relation_between_Room_FeaturedDeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("f3f031e4-3851-47ac-adc2-138aa73ec868"), new DateTime(2024, 2, 4, 18, 15, 38, 687, DateTimeKind.Local).AddTicks(6240), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedDeals_RoomId",
                table: "FeaturedDeals",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedDeals_Rooms_RoomId",
                table: "FeaturedDeals",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("f3f031e4-3851-47ac-adc2-138aa73ec868"));

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
    }
}
