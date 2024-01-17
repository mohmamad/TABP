using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Loacation_and_city_datamodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("007792cc-d1ed-41a6-922c-5fe857ecae61"));

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Locations",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Locations",
                newName: "PostalCode");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("4747093d-c40d-4210-8319-a3da5f1ea435"), new DateTime(2024, 1, 13, 20, 52, 54, 328, DateTimeKind.Local).AddTicks(3237), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CityId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("4747093d-c40d-4210-8319-a3da5f1ea435"));

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Locations",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Locations",
                newName: "CityName");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName", "Password", "UserLevel" },
                values: new object[] { new Guid("007792cc-d1ed-41a6-922c-5fe857ecae61"), new DateTime(2024, 1, 1, 4, 6, 42, 272, DateTimeKind.Local).AddTicks(4147), "mohamad.moghrabi@gmail.com", "mohamad", "moghrabi", "1234", 1 });
        }
    }
}
