using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class IntialCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "air_company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tittle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_air_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tittle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middlename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_company = table.Column<int>(type: "int", nullable: false),
                    distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.id);
                    table.ForeignKey(
                        name: "FK__plans__id_compan__3F466844",
                        column: x => x.id_company,
                        principalTable: "air_company",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "air_lines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_company = table.Column<int>(type: "int", nullable: true),
                    id_planes = table.Column<int>(type: "int", nullable: true),
                    city_departure = table.Column<int>(type: "int", nullable: true),
                    datetime_departure = table.Column<DateTime>(type: "datetime", nullable: true),
                    city_arrival = table.Column<int>(type: "int", nullable: true),
                    datetime_arrival = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_air_lines", x => x.id);
                    table.ForeignKey(
                        name: "FK__air_lines__city___440B1D61",
                        column: x => x.city_departure,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__air_lines__city___44FF419A",
                        column: x => x.city_arrival,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__air_lines__id_co__4222D4EF",
                        column: x => x.id_company,
                        principalTable: "air_company",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__air_lines__id_pl__4316F928",
                        column: x => x.id_planes,
                        principalTable: "plans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    id_air_lines = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK__tickets__id_air___45F365D3",
                        column: x => x.id_air_lines,
                        principalTable: "air_lines",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__tickets__id_user__38996AB5",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_air_lines_city_arrival",
                table: "air_lines",
                column: "city_arrival");

            migrationBuilder.CreateIndex(
                name: "IX_air_lines_city_departure",
                table: "air_lines",
                column: "city_departure");

            migrationBuilder.CreateIndex(
                name: "IX_air_lines_id_company",
                table: "air_lines",
                column: "id_company");

            migrationBuilder.CreateIndex(
                name: "IX_air_lines_id_planes",
                table: "air_lines",
                column: "id_planes");

            migrationBuilder.CreateIndex(
                name: "IX_plans_id_company",
                table: "plans",
                column: "id_company");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_air_lines",
                table: "tickets",
                column: "id_air_lines");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_user",
                table: "tickets",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "air_lines");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "plans");

            migrationBuilder.DropTable(
                name: "air_company");
        }
    }
}
