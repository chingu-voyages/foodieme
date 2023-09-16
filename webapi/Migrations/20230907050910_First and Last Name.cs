using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstandLastName : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "DateJoined", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec9eaaf6-ac88-429e-a3c4-437ac8de36cc", new DateTime(2023, 9, 7, 5, 9, 10, 568, DateTimeKind.Utc).AddTicks(7638), null, null, "AQAAAAIAAYagAAAAEGwpa15ss2K52hR0TwRqA7szNcMtuCmXUGq455KPRdfWL2ZAA33EIuRgkALs51DlmQ==", "8b104762-f73a-439f-82a6-2d33da0fb18f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb44616c-38dc-422a-92ee-6f1f194d49f2", new DateTime(2023, 9, 7, 5, 9, 10, 621, DateTimeKind.Utc).AddTicks(4943), null, null, "AQAAAAIAAYagAAAAEFEDzbK/tOBeu2rHSx0PqxJQPbjftjcnRPQtIgMLGU9Hh4eqmVI+IU2GWRZFxe07aA==", "ec3a20c8-e38b-4969-bf2c-a0e63bf39fe0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ec08051-c25b-4103-9ed8-6f0110035524", new DateTime(2023, 9, 7, 5, 9, 10, 673, DateTimeKind.Utc).AddTicks(5065), null, null, "AQAAAAIAAYagAAAAEBNbjYSG24i9gccoZ1AxRUoJtC/qDkIZxUMzkfEul5T1ZJJtwpDI8W9xAesotPhbaQ==", "e00dc347-f4e5-4bf2-8cac-8e4376d643f7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75ffdb9c-1704-4158-8529-bf75c672d1ef", new DateTime(2023, 9, 7, 5, 9, 10, 728, DateTimeKind.Utc).AddTicks(2454), null, null, "AQAAAAIAAYagAAAAEKfkIKcBGMAFOtUONklbghQ3aCJ9fHx6+ZZV6iiuWxUuJEO/Toj7iRzmthcIWa7OTQ==", "be624c88-406d-42ef-bc5c-8847afaf9658" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb1bf862-5ed4-4289-a0fc-af94a700d02a", new DateTime(2023, 9, 7, 5, 9, 10, 780, DateTimeKind.Utc).AddTicks(3288), null, null, "AQAAAAIAAYagAAAAEIO+epgnmZAX1YoYN2r0m5qtUM3EnIhbAZCWjtlAqhwHIqkKjUE565HfcjRuUckuyg==", "d4e9f547-470b-4a95-81e4-b7ea7bd88e68" });

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
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f17d68d-6188-451b-8db9-c21aff14c07a", new DateTime(2023, 8, 28, 3, 22, 10, 461, DateTimeKind.Utc).AddTicks(1538), "AQAAAAIAAYagAAAAEC64ENJQL7vEvrBwrAnU5oI37kiCFvRjNp1nbMT6eXqD3sqqiNtP4gkdS4M7FcsxQQ==", "125c4bd8-4e3b-4dad-b394-b04ce75d90da" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce474f9e-7b47-44f0-bb27-b8763ad0f905", new DateTime(2023, 8, 28, 3, 22, 10, 518, DateTimeKind.Utc).AddTicks(3820), "AQAAAAIAAYagAAAAEObx96fSrymchuuIjhbyALzVtU0D0d11W8WqI50gLpLZruqC1lNS3YmvfBL0wCHVcg==", "f0992a4f-ad64-4456-b13a-bacc7a2aa78c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c6c22dc-8558-4efe-891a-ea54292d93d6", new DateTime(2023, 8, 28, 3, 22, 10, 569, DateTimeKind.Utc).AddTicks(7112), "AQAAAAIAAYagAAAAEAVnQ/V+QzOcG8A8CRMX7JjYHWkz1vLUn9CPOxx8rFx4MkJ4kZIfTY6ftijBtK/5TA==", "96451911-98c7-45fe-96c2-f93dc1378d68" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "924bc51f-3c3e-401f-8a78-3dc024952c41", new DateTime(2023, 8, 28, 3, 22, 10, 622, DateTimeKind.Utc).AddTicks(2956), "AQAAAAIAAYagAAAAEF/c2cl66dROEaD78OgAgsP1D2oXHUVECGnSYlFCvW1F+yqH6LMXPoX3m4oap1yQHA==", "6d3c3065-b28e-4630-9798-4003d14df323" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba556184-5792-49c8-90ba-552324180edc", new DateTime(2023, 8, 28, 3, 22, 10, 674, DateTimeKind.Utc).AddTicks(6846), "AQAAAAIAAYagAAAAEEedq7AMJZq2KERqRzeev97qTMeCRu1kk0cndzLe6tZiaBF0YkKWRk8yeezCutZRGg==", "9bee7034-a82f-4955-9ebc-cd55557ec09a" });

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
    }
}
