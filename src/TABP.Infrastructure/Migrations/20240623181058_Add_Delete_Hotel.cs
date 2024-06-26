using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Delete_Hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

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

            migrationBuilder.InsertData(
                table: "HotelTypes",
                columns: new[] { "HotelTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("0de1e7b6-2cfb-4bf9-a931-91b01490082e"), "nice" },
                    { new Guid("a7e01843-d8f5-4a28-875f-3b925eb19e64"), "perfect" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("807239a5-1448-409a-8eb9-9c3a70b27350"), "perfect" },
                    { new Guid("a5177f7f-a4d6-435c-9101-13d89dcfc03d"), "nice" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("0de1e7b6-2cfb-4bf9-a931-91b01490082e"));

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("a7e01843-d8f5-4a28-875f-3b925eb19e64"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("807239a5-1448-409a-8eb9-9c3a70b27350"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("a5177f7f-a4d6-435c-9101-13d89dcfc03d"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");
        }
    }
}
