using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Cities_CityId",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Reviews",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCount",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CityId", "Date", "ReviewScore", "ReviewText", "UserName" },
                values: new object[] { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Wonderful city, a lot to do and see!", "Kurokeh" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CityId", "Date", "ReviewScore", "ReviewText", "UserName" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Okay but it smelled like weed everywhere", "Bmead" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CityId", "Date", "ReviewScore", "ReviewText", "UserName" },
                values: new object[] { 3, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Lovely city, some of the people weren't nice though", "Bmead" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Cities_CityId",
                table: "Reviews",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Cities_CityId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ReviewCount",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Cities_CityId",
                table: "Reviews",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
