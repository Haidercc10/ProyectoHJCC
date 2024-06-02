using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class Model_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Us_Id = table.Column<long>(type: "bigint", nullable: false),
                    Us_Code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Us_Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    DocType_Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false),
                    Status_Id = table.Column<int>(type: "int", nullable: false),
                    Us_ProfessionalProfile = table.Column<string>(type: "varchar(max)", nullable: false),
                    Us_DateBorn = table.Column<DateTime>(type: "date", nullable: false),
                    Us_CityBorn = table.Column<string>(type: "varchar(100)", nullable: false),
                    Status_Civil = table.Column<int>(type: "int", nullable: false),
                    Us_Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    Us_Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Us_Adress = table.Column<string>(type: "varchar(max)", nullable: false),
                    Us_CurrentCity = table.Column<string>(type: "varchar(100)", nullable: false),
                    Us_DateCreation = table.Column<DateTime>(type: "date", nullable: false),
                    Us_HourCreation = table.Column<string>(type: "varchar(20)", nullable: false),
                    Us_Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    Us_Observation = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Us_Id);
                    table.ForeignKey(
                        name: "FK_Users_Documents_Types_DocType_Id",
                        column: x => x.DocType_Id,
                        principalTable: "Documents_Types",
                        principalColumn: "DocType_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Rol_Id",
                        column: x => x.Rol_Id,
                        principalTable: "Roles",
                        principalColumn: "Rol_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_Status_Civil",
                        column: x => x.Status_Civil,
                        principalTable: "Statuses",
                        principalColumn: "Status_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_Status_Id",
                        column: x => x.Status_Id,
                        principalTable: "Statuses",
                        principalColumn: "Status_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DocType_Id",
                table: "Users",
                column: "DocType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Rol_Id",
                table: "Users",
                column: "Rol_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Status_Civil",
                table: "Users",
                column: "Status_Civil");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Status_Id",
                table: "Users",
                column: "Status_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
