using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class StatusTypesInStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Staty_Id",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_Staty_Id",
                table: "Statuses",
                column: "Staty_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Status_Types_Staty_Id",
                table: "Statuses",
                column: "Staty_Id",
                principalTable: "Status_Types",
                principalColumn: "Staty_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Status_Types_Staty_Id",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_Staty_Id",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "Staty_Id",
                table: "Statuses");
        }
    }
}
