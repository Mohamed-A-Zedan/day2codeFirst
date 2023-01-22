using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task2fromcode.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorksFor");

            migrationBuilder.CreateTable(
                name: "WorkOns",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Pnum = table.Column<int>(type: "int", nullable: false),
                    hour = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOns", x => new { x.ESSN, x.Pnum });
                    table.ForeignKey(
                        name: "FK_WorkOns_Projects_Pnum",
                        column: x => x.Pnum,
                        principalTable: "Projects",
                        principalColumn: "Pnumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOns_employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOns_Pnum",
                table: "WorkOns",
                column: "Pnum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOns");

            migrationBuilder.CreateTable(
                name: "WorksFor",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Pnum = table.Column<int>(type: "int", nullable: false),
                    hour = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksFor", x => new { x.ESSN, x.Pnum });
                    table.ForeignKey(
                        name: "FK_WorksFor_Projects_Pnum",
                        column: x => x.Pnum,
                        principalTable: "Projects",
                        principalColumn: "Pnumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksFor_employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorksFor_Pnum",
                table: "WorksFor",
                column: "Pnum");
        }
    }
}
