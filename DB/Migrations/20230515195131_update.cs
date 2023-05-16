using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plans_TypeOfPlan_TypeOfPlanId",
                table: "plans");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_Dinner_DinnerId",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfPlan",
                table: "TypeOfPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dinner",
                table: "Dinner");

            migrationBuilder.RenameTable(
                name: "TypeOfPlan",
                newName: "TypeOfPlans");

            migrationBuilder.RenameTable(
                name: "Dinner",
                newName: "Dinners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfPlans",
                table: "TypeOfPlans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dinners",
                table: "Dinners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plans_TypeOfPlans_TypeOfPlanId",
                table: "plans",
                column: "TypeOfPlanId",
                principalTable: "TypeOfPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_Dinners_DinnerId",
                table: "tickets",
                column: "DinnerId",
                principalTable: "Dinners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plans_TypeOfPlans_TypeOfPlanId",
                table: "plans");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_Dinners_DinnerId",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfPlans",
                table: "TypeOfPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dinners",
                table: "Dinners");

            migrationBuilder.RenameTable(
                name: "TypeOfPlans",
                newName: "TypeOfPlan");

            migrationBuilder.RenameTable(
                name: "Dinners",
                newName: "Dinner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfPlan",
                table: "TypeOfPlan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dinner",
                table: "Dinner",
                column: "Id");

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
    }
}
