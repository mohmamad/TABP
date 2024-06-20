using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Add_Room_Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ImagePath",
                table: "RoomImages",
                newName: "ImageBath");

            migrationBuilder.InsertData(
                table: "HotelTypes",
                columns: new[] { "HotelTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("bad40df6-79e5-4ab4-87cd-5957b2a4267b"), "perfect" },
                    { new Guid("c99cee82-254a-4690-8f7a-6cc4e14c9b1b"), "nice" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("07d53cee-74ef-4f1c-a106-542d1d784e7e"), "nice" },
                    { new Guid("2609ee5f-14c3-40be-babb-863277aadec9"), "perfect" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("bad40df6-79e5-4ab4-87cd-5957b2a4267b"));

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("c99cee82-254a-4690-8f7a-6cc4e14c9b1b"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("07d53cee-74ef-4f1c-a106-542d1d784e7e"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("2609ee5f-14c3-40be-babb-863277aadec9"));

            migrationBuilder.RenameColumn(
                name: "ImageBath",
                table: "RoomImages",
                newName: "ImagePath");

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
        }
    }
}
