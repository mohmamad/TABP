using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_IsRoomAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ba75ce79-9f45-4a8e-851e-bb101d08f852"));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaiable",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("dacc660c-f94c-48f4-a0e6-18839d3ae6e2"), new DateTime(2024, 1, 30, 17, 55, 23, 802, DateTimeKind.Local).AddTicks(1566), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("dacc660c-f94c-48f4-a0e6-18839d3ae6e2"));

            migrationBuilder.DropColumn(
                name: "IsAvaiable",
                table: "Rooms");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("ba75ce79-9f45-4a8e-851e-bb101d08f852"), new DateTime(2024, 1, 27, 2, 35, 45, 790, DateTimeKind.Local).AddTicks(4777), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 2 });
        }
    }
}
