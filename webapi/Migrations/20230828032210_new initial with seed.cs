using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class newinitialwithseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BudgetMin = table.Column<int>(type: "int", nullable: true),
                    BudgetMax = table.Column<int>(type: "int", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealRequests_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MealRequests_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MealRequestsCompanions",
                columns: table => new
                {
                    CompanionsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MealRequestModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRequestsCompanions", x => new { x.CompanionsId, x.MealRequestModelId });
                    table.ForeignKey(
                        name: "FK_MealRequestsCompanions_MealRequests_MealRequestModelId",
                        column: x => x.MealRequestModelId,
                        principalTable: "MealRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MealRequestsCompanions_Users_CompanionsId",
                        column: x => x.CompanionsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BudgetMax", "BudgetMin", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, null, null, "5f17d68d-6188-451b-8db9-c21aff14c07a", new DateTime(2023, 8, 28, 3, 22, 10, 461, DateTimeKind.Utc).AddTicks(1538), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@test.ca", true, false, null, "USER1@TEST.CA", "USER1", "AQAAAAIAAYagAAAAEC64ENJQL7vEvrBwrAnU5oI37kiCFvRjNp1nbMT6eXqD3sqqiNtP4gkdS4M7FcsxQQ==", null, false, null, "125c4bd8-4e3b-4dad-b394-b04ce75d90da", false, "user1" },
                    { "2", 0, null, null, "ce474f9e-7b47-44f0-bb27-b8763ad0f905", new DateTime(2023, 8, 28, 3, 22, 10, 518, DateTimeKind.Utc).AddTicks(3820), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@test.ca", true, false, null, "USER2@TEST.CA", "USER2", "AQAAAAIAAYagAAAAEObx96fSrymchuuIjhbyALzVtU0D0d11W8WqI50gLpLZruqC1lNS3YmvfBL0wCHVcg==", null, false, null, "f0992a4f-ad64-4456-b13a-bacc7a2aa78c", false, "user2" },
                    { "3", 0, null, null, "3c6c22dc-8558-4efe-891a-ea54292d93d6", new DateTime(2023, 8, 28, 3, 22, 10, 569, DateTimeKind.Utc).AddTicks(7112), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@test.ca", true, false, null, "USER3@TEST.CA", "USER3", "AQAAAAIAAYagAAAAEAVnQ/V+QzOcG8A8CRMX7JjYHWkz1vLUn9CPOxx8rFx4MkJ4kZIfTY6ftijBtK/5TA==", null, false, null, "96451911-98c7-45fe-96c2-f93dc1378d68", false, "user3" },
                    { "4", 0, null, null, "924bc51f-3c3e-401f-8a78-3dc024952c41", new DateTime(2023, 8, 28, 3, 22, 10, 622, DateTimeKind.Utc).AddTicks(2956), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@test.ca", true, false, null, "USER4@TEST.CA", "USER4", "AQAAAAIAAYagAAAAEF/c2cl66dROEaD78OgAgsP1D2oXHUVECGnSYlFCvW1F+yqH6LMXPoX3m4oap1yQHA==", null, false, null, "6d3c3065-b28e-4630-9798-4003d14df323", false, "user4" },
                    { "5", 0, null, null, "ba556184-5792-49c8-90ba-552324180edc", new DateTime(2023, 8, 28, 3, 22, 10, 674, DateTimeKind.Utc).AddTicks(6846), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@test.ca", true, false, null, "USER5@TEST.CA", "USER5", "AQAAAAIAAYagAAAAEEedq7AMJZq2KERqRzeev97qTMeCRu1kk0cndzLe6tZiaBF0YkKWRk8yeezCutZRGg==", null, false, null, "9bee7034-a82f-4955-9ebc-cd55557ec09a", false, "user5" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Budget", "CreatorId", "DateCreated", "DateUpdated", "Description", "Name", "Style" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "$$$", "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A cozy place with delicious food.", "Restaurant 1", "Italian" },
                    { 2, "456 Elm Avenue", "$$", "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Authentic flavors from around the world.", "Restaurant 2", "Asian Fusion" },
                    { 3, "789 Oak Street", "$$$", "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A modern atmosphere with a diverse menu.", "Restaurant 3", "American" },
                    { 4, "101 Maple Road", "$$$$", "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience fine dining at its best.", "Restaurant 4", "French" },
                    { 5, "222 Pine Lane", "$$", "5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savor the taste of authentic sushi.", "Restaurant 5", "Japanese" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealRequests_CreatorId",
                table: "MealRequests",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MealRequests_RestaurantId",
                table: "MealRequests",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MealRequestsCompanions_MealRequestModelId",
                table: "MealRequestsCompanions",
                column: "MealRequestModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CreatorId",
                table: "Restaurants",
                column: "CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealRequestsCompanions");

            migrationBuilder.DropTable(
                name: "MealRequests");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
