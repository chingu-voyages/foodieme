using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class add_MR_Datetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealRequests_Restaurants_RestaurantId",
                table: "MealRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MealRequests_Users_CreatorId",
                table: "MealRequests");

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Budget",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "MealRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "MealRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "MealRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73c1e9c7-646e-46b0-b100-506a549fe575", new DateTime(2023, 9, 18, 0, 57, 59, 269, DateTimeKind.Utc).AddTicks(2198), "AQAAAAIAAYagAAAAEOLwDxgAdz/gqOuX/K+MyUrlsves0mxlPn25WCNpgRribEcVDQRxnqvd6NMLV6lmxQ==", "ff096cd8-1dff-41b5-8cdd-d0bba22cd194" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "196ba4fc-66e7-47cb-90df-bfb30eb24979", new DateTime(2023, 9, 18, 0, 57, 59, 332, DateTimeKind.Utc).AddTicks(4890), "AQAAAAIAAYagAAAAEDANC0K3J8c7jtUvz/nCNL0KswJRXNObuDT04J3x/69prrbbWvCBasDFZ7moE32aCg==", "77982906-46ff-4600-b293-51f3b735124a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eebb62e-8c6f-4e8f-b943-192b537e0b9d", new DateTime(2023, 9, 18, 0, 57, 59, 386, DateTimeKind.Utc).AddTicks(7184), "AQAAAAIAAYagAAAAEMpAjpU9BNcfw2lYzQKzpuCIqM0xOUMUk/pUPkz7ZWhqlX3gEMX2OtbM+hJ8axM+HA==", "c4a0f261-f421-4888-bf6a-2c948a28d3f9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04f0e5b2-a00e-4d5f-bbe1-74450198b764", new DateTime(2023, 9, 18, 0, 57, 59, 438, DateTimeKind.Utc).AddTicks(5385), "AQAAAAIAAYagAAAAEKx2knW+L2M6fqXidC7vKYuRufmTY+AzsV/JKCkS7gVXn52oLQuols2xeIojg2hOww==", "2cb7a4c3-f94f-4409-a1a5-5deea65f4798" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d312f5e-79a6-40a1-ba3c-6ab38aca5dea", new DateTime(2023, 9, 18, 0, 57, 59, 493, DateTimeKind.Utc).AddTicks(2620), "AQAAAAIAAYagAAAAEIHJucPYKpVc+NOCyzvhWmTvO7BU622RdnXAuwNC5LSyoB3t2aiT985gxnVfAqFhkQ==", "e58bd34d-91f2-4b59-8050-99063e2ac3e0" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealRequests_Restaurants_RestaurantId",
                table: "MealRequests",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealRequests_Users_CreatorId",
                table: "MealRequests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealRequests_Restaurants_RestaurantId",
                table: "MealRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MealRequests_Users_CreatorId",
                table: "MealRequests");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "MealRequests");

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Budget",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "MealRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "MealRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec9eaaf6-ac88-429e-a3c4-437ac8de36cc", new DateTime(2023, 9, 7, 5, 9, 10, 568, DateTimeKind.Utc).AddTicks(7638), "AQAAAAIAAYagAAAAEGwpa15ss2K52hR0TwRqA7szNcMtuCmXUGq455KPRdfWL2ZAA33EIuRgkALs51DlmQ==", "8b104762-f73a-439f-82a6-2d33da0fb18f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb44616c-38dc-422a-92ee-6f1f194d49f2", new DateTime(2023, 9, 7, 5, 9, 10, 621, DateTimeKind.Utc).AddTicks(4943), "AQAAAAIAAYagAAAAEFEDzbK/tOBeu2rHSx0PqxJQPbjftjcnRPQtIgMLGU9Hh4eqmVI+IU2GWRZFxe07aA==", "ec3a20c8-e38b-4969-bf2c-a0e63bf39fe0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ec08051-c25b-4103-9ed8-6f0110035524", new DateTime(2023, 9, 7, 5, 9, 10, 673, DateTimeKind.Utc).AddTicks(5065), "AQAAAAIAAYagAAAAEBNbjYSG24i9gccoZ1AxRUoJtC/qDkIZxUMzkfEul5T1ZJJtwpDI8W9xAesotPhbaQ==", "e00dc347-f4e5-4bf2-8cac-8e4376d643f7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75ffdb9c-1704-4158-8529-bf75c672d1ef", new DateTime(2023, 9, 7, 5, 9, 10, 728, DateTimeKind.Utc).AddTicks(2454), "AQAAAAIAAYagAAAAEKfkIKcBGMAFOtUONklbghQ3aCJ9fHx6+ZZV6iiuWxUuJEO/Toj7iRzmthcIWa7OTQ==", "be624c88-406d-42ef-bc5c-8847afaf9658" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb1bf862-5ed4-4289-a0fc-af94a700d02a", new DateTime(2023, 9, 7, 5, 9, 10, 780, DateTimeKind.Utc).AddTicks(3288), "AQAAAAIAAYagAAAAEIO+epgnmZAX1YoYN2r0m5qtUM3EnIhbAZCWjtlAqhwHIqkKjUE565HfcjRuUckuyg==", "d4e9f547-470b-4a95-81e4-b7ea7bd88e68" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealRequests_Restaurants_RestaurantId",
                table: "MealRequests",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealRequests_Users_CreatorId",
                table: "MealRequests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
