using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestaurantsMealRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0376a7b-05bc-425d-8822-fabad0958951", new DateTime(2023, 9, 23, 17, 51, 48, 147, DateTimeKind.Utc).AddTicks(391), "AQAAAAIAAYagAAAAELwyhDo5VXyKITRzIiHHSiOtxeJPYVQmc3lJiyrspZ8kCFEM2nu2n2kcL73eN5olvg==", "31995640-351b-45de-947e-216c01f27fea" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "563238f3-6e9a-422c-ae7f-9e562636aba3", new DateTime(2023, 9, 23, 17, 51, 48, 297, DateTimeKind.Utc).AddTicks(7087), "AQAAAAIAAYagAAAAEByGvfTJx+7IIItGZG+M4p2uhYLVQhFNigWGHL2lqBol1cl9pUxw8yY9qvSmRQXuKg==", "69b014e7-3303-4362-ae01-cb7a937ca0aa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "097aeb1b-9152-4785-8cd6-7ebf1fb79fc9", new DateTime(2023, 9, 23, 17, 51, 48, 455, DateTimeKind.Utc).AddTicks(6124), "AQAAAAIAAYagAAAAEAHGrvNgNslFj3+XTyKc7EXKHcNE9LjvihHGlMtVyCCl/gRZn0PO+3ZFkbX2YHY1Ng==", "b0806fe4-2d83-49b5-bd8e-515a4b85287f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91c5b935-b11c-4abc-acf8-5bbf657374bb", new DateTime(2023, 9, 23, 17, 51, 48, 619, DateTimeKind.Utc).AddTicks(1917), "AQAAAAIAAYagAAAAEHp4Jmgh7FE9FuuqZ6MMf0rms0S6FEjYRLjMv+xDTFhnsqQA6Prw2BG1an+XXd6hBg==", "ff8b328a-1b5e-4f21-9503-799f3812a519" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be502600-4a08-4fb4-8005-f09e277148aa", new DateTime(2023, 9, 23, 17, 51, 48, 751, DateTimeKind.Utc).AddTicks(9544), "AQAAAAIAAYagAAAAEKR7g7/LLdvpDGYT5V8tzGIxpoz38SCNHXnnp2/9iF5u7WVXISaH0m+1LGV3dMwwQQ==", "b1679f61-0ee1-4b7b-8fa6-3498ea017da9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
