using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddMealRequestsToRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97ef8d94-32e2-4cae-87e8-828a2072d9f2", new DateTime(2023, 9, 23, 17, 41, 24, 348, DateTimeKind.Utc).AddTicks(6515), "AQAAAAIAAYagAAAAEP3LWqDt0aU6ybSun9xV0I5NHyTdVGwGS0FwVSPKc5FEpYOIdQEC5H/s80gBvCmXyQ==", "9f26d89a-006f-459b-a655-7f8dd3892431" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dba33f1c-d4e4-4662-8467-a952e5b8b203", new DateTime(2023, 9, 23, 17, 41, 24, 489, DateTimeKind.Utc).AddTicks(2371), "AQAAAAIAAYagAAAAEApGlNFuCgvWtUKaCMX9vBQSIVVJDV+fuEcxfAcqbqprbRSqnmPQ8PQQLv5WtpTd/A==", "eddfa61c-0315-47df-b9bb-4bdb182d4425" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6be36fe6-3c88-4d26-b3d4-34c85fddacb6", new DateTime(2023, 9, 23, 17, 41, 24, 639, DateTimeKind.Utc).AddTicks(2679), "AQAAAAIAAYagAAAAEES55F1MxlIbJBwGGm3bi5FmMtL5wRXa95G2A45UepKOfEUbQclXGB+5kvWqupKmRw==", "3833b5df-ac0a-493d-937d-441823887572" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4a695f4-347e-4cb4-8481-757b529ae2bf", new DateTime(2023, 9, 23, 17, 41, 24, 784, DateTimeKind.Utc).AddTicks(2213), "AQAAAAIAAYagAAAAEAl8YKRmXCEInqhiDgTjHm9HvOIsCCRccj5y6feKPXID63TXBBrGFd1EV7RINtmwcg==", "e090f09b-0b9c-4cf1-a159-db9edfa43510" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1729cbb0-96a8-4423-a5c1-e12a119749f4", new DateTime(2023, 9, 23, 17, 41, 24, 921, DateTimeKind.Utc).AddTicks(1675), "AQAAAAIAAYagAAAAEA1e9xcR12zUPVwo2ss0WK8QBwZ2mbFTSNd4c+/uTYYqWYy/YXNcvc3WC+hMe6qCyA==", "9a3b6187-48bc-484a-a49f-d911f2f9ee63" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
