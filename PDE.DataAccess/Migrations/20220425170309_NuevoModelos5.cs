using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDE.DataAccess.Migrations
{
    public partial class NuevoModelos5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Categorias_CategoriaId",
                table: "Miembro");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Miembro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Categorias_CategoriaId",
                table: "Miembro",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Categorias_CategoriaId",
                table: "Miembro");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Miembro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Categorias_CategoriaId",
                table: "Miembro",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
