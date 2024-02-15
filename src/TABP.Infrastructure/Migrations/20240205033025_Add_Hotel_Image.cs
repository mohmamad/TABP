using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Hotel_Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Hotels_HotelId",
                table: "HotelImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelImage",
                table: "HotelImage");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d21efa00-2b37-4116-b5cf-34c444215604"));

            migrationBuilder.RenameTable(
                name: "HotelImage",
                newName: "HotelImages");

            migrationBuilder.RenameIndex(
                name: "IX_HotelImage_HotelId",
                table: "HotelImages",
                newName: "IX_HotelImages_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages",
                column: "HotelImageId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("eeea62a5-263b-442d-a2d9-9798765c60c5"), new DateTime(2024, 2, 5, 5, 30, 25, 723, DateTimeKind.Local).AddTicks(8167), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImages_Hotels_HotelId",
                table: "HotelImages",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImages_Hotels_HotelId",
                table: "HotelImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("eeea62a5-263b-442d-a2d9-9798765c60c5"));

            migrationBuilder.RenameTable(
                name: "HotelImages",
                newName: "HotelImage");

            migrationBuilder.RenameIndex(
                name: "IX_HotelImages_HotelId",
                table: "HotelImage",
                newName: "IX_HotelImage_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelImage",
                table: "HotelImage",
                column: "HotelImageId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("d21efa00-2b37-4116-b5cf-34c444215604"), new DateTime(2024, 2, 4, 18, 16, 54, 733, DateTimeKind.Local).AddTicks(2713), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImage_Hotels_HotelId",
                table: "HotelImage",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
