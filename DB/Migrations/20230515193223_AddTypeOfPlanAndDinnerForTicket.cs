using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class AddTypeOfPlanAndDinnerForTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DinnerId",
                table: "tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPlanId",
                table: "plans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dinner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPlan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_DinnerId",
                table: "tickets",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_plans_TypeOfPlanId",
                table: "plans",
                column: "TypeOfPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_plans_TypeOfPlan_TypeOfPlanId",
                table: "plans",
                column: "TypeOfPlanId",
                principalTable: "TypeOfPlan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_Dinner_DinnerId",
                table: "tickets",
                column: "DinnerId",
                principalTable: "Dinner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plans_TypeOfPlan_TypeOfPlanId",
                table: "plans");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_Dinner_DinnerId",
                table: "tickets");

            migrationBuilder.DropTable(
                name: "Dinner");

            migrationBuilder.DropTable(
                name: "TypeOfPlan");

            migrationBuilder.DropIndex(
                name: "IX_tickets_DinnerId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_plans_TypeOfPlanId",
                table: "plans");

            migrationBuilder.DropColumn(
                name: "DinnerId",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "TypeOfPlanId",
                table: "plans");
        }
    }
}
