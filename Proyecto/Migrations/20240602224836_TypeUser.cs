using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class TypeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeUser_Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeUser",
                columns: table => new
                {
                    TypeUser_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUser_Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    TypeUser_Description = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUser", x => x.TypeUser_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeUser_Id",
                table: "Users",
                column: "TypeUser_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TypeUser_TypeUser_Id",
                table: "Users",
                column: "TypeUser_Id",
                principalTable: "TypeUser",
                principalColumn: "TypeUser_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypeUser_TypeUser_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TypeUser");

            migrationBuilder.DropIndex(
                name: "IX_Users_TypeUser_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeUser_Id",
                table: "Users");
        }
    }
}
