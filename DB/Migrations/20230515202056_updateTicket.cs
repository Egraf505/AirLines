using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class updateTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plans_TypeOfPlans_TypeOfPlanId",
                table: "plans");

            migrationBuilder.DropIndex(
                name: "IX_plans_TypeOfPlanId",
                table: "plans");

            migrationBuilder.DropColumn(
                name: "TypeOfPlanId",
                table: "plans");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPlanId",
                table: "tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_TypeOfPlanId",
                table: "tickets",
                column: "TypeOfPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_TypeOfPlans_TypeOfPlanId",
                table: "tickets",
                column: "TypeOfPlanId",
                principalTable: "TypeOfPlans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_TypeOfPlans_TypeOfPlanId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_TypeOfPlanId",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "TypeOfPlanId",
                table: "tickets");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPlanId",
                table: "plans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_plans_TypeOfPlanId",
                table: "plans",
                column: "TypeOfPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_plans_TypeOfPlans_TypeOfPlanId",
                table: "plans",
                column: "TypeOfPlanId",
                principalTable: "TypeOfPlans",
                principalColumn: "Id");
        }
    }
}
