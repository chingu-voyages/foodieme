using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Manytomanyrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MealRequests_MealRequestModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MealRequestModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MealRequestModelId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CreatorId",
                table: "Restaurants",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MealRequestsCompanions_MealRequestModelId",
                table: "MealRequestsCompanions",
                column: "MealRequestModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_CreatorId",
                table: "Restaurants",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_CreatorId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "MealRequestsCompanions");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CreatorId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "MealRequestModelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MealRequestModelId",
                table: "Users",
                column: "MealRequestModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MealRequests_MealRequestModelId",
                table: "Users",
                column: "MealRequestModelId",
                principalTable: "MealRequests",
                principalColumn: "Id");
        }
    }
}
