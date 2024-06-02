using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Forget_Password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("03bfa6a3-5271-4ac1-b6b8-e16446de8163"));

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("73fa565e-fda1-47f8-892d-0158b7717e8f"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("902fbc41-479e-4921-b30a-369be57aea02"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("f5e4f671-54fd-48cb-b67f-fae0641d4eda"));

            migrationBuilder.CreateTable(
                name: "ResetPasswordCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPasswordCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResetPasswordCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotelTypes",
                columns: new[] { "HotelTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("26614205-a983-4284-ab44-4d00ffaaaa50"), "nice" },
                    { new Guid("5d1ec709-58b6-4ef0-8d4e-880079384059"), "perfect" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("15c3baee-7a62-4dd0-a11b-eb079cf645d4"), "nice" },
                    { new Guid("85ac6be7-ca03-4ccb-8c4c-11bcc6353e66"), "perfect" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswordCodes_UserId",
                table: "ResetPasswordCodes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResetPasswordCodes");

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("26614205-a983-4284-ab44-4d00ffaaaa50"));

            migrationBuilder.DeleteData(
                table: "HotelTypes",
                keyColumn: "HotelTypeId",
                keyValue: new Guid("5d1ec709-58b6-4ef0-8d4e-880079384059"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("15c3baee-7a62-4dd0-a11b-eb079cf645d4"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("85ac6be7-ca03-4ccb-8c4c-11bcc6353e66"));

            migrationBuilder.InsertData(
                table: "HotelTypes",
                columns: new[] { "HotelTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("03bfa6a3-5271-4ac1-b6b8-e16446de8163"), "perfect" },
                    { new Guid("73fa565e-fda1-47f8-892d-0158b7717e8f"), "nice" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("902fbc41-479e-4921-b30a-369be57aea02"), "nice" },
                    { new Guid("f5e4f671-54fd-48cb-b67f-fae0641d4eda"), "perfect" }
                });
        }
    }
}
