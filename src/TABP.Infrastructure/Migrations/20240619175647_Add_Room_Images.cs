using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Room_Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("18fa87d4-d102-4f5d-a95a-902f310be559"));

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("9965e86a-41a0-4556-8ce0-9635a5bd3a59"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("2f786c1c-b049-4095-81f2-e3bf5e12c05c"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("3263203d-e8bc-4105-a5c9-71b7371b4b53"));

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ResetPasswordCodes",
                newName: "Code");

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    RoomImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.RoomImageId);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotelTypes",
                columns: new[] { "HotelTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("8da47d1e-a6ad-4b93-9090-9e7f8239e1c6"), "nice" },
                    { new Guid("fad83135-c50c-4492-a121-9700e55395f6"), "perfect" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("61d537be-b232-4e48-a117-b8362e5c1be9"), "perfect" },
                    { new Guid("63c826f3-35de-4c64-96a3-dfa50f38e896"), "nice" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("8da47d1e-a6ad-4b93-9090-9e7f8239e1c6"));

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("fad83135-c50c-4492-a121-9700e55395f6"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("61d537be-b232-4e48-a117-b8362e5c1be9"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("63c826f3-35de-4c64-96a3-dfa50f38e896"));

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ResetPasswordCodes",
                newName: "code");

            migrationBuilder.InsertData(
                table: "HotelTypes",
                columns: new[] { "HotelTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("18fa87d4-d102-4f5d-a95a-902f310be559"), "nice" },
                    { new Guid("9965e86a-41a0-4556-8ce0-9635a5bd3a59"), "perfect" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("2f786c1c-b049-4095-81f2-e3bf5e12c05c"), "perfect" },
                    { new Guid("3263203d-e8bc-4105-a5c9-71b7371b4b53"), "nice" }
                });
        }
    }
}
