using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDE.Persistence.Migrations
{
    public partial class reestructuracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Cargo_CargoId",
                table: "Miembro");

            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Estructuras_EstructuraId",
                table: "Miembro");

            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Localidad_LocalidadId",
                table: "Miembro");

            migrationBuilder.DropIndex(
                name: "IX_Miembro_CargoId",
                table: "Miembro");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Miembro");

            migrationBuilder.RenameColumn(
                name: "EstructuraId",
                table: "Miembro",
                newName: "CargoTerritorialId");

            migrationBuilder.RenameIndex(
                name: "IX_Miembro_EstructuraId",
                table: "Miembro",
                newName: "IX_Miembro_CargoTerritorialId");

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadId",
                table: "Miembro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_CargoTerritorial_CargoTerritorialId",
                table: "Miembro",
                column: "CargoTerritorialId",
                principalTable: "CargoTerritorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Localidad_LocalidadId",
                table: "Miembro",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_CargoTerritorial_CargoTerritorialId",
                table: "Miembro");

            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Localidad_LocalidadId",
                table: "Miembro");

            migrationBuilder.RenameColumn(
                name: "CargoTerritorialId",
                table: "Miembro",
                newName: "EstructuraId");

            migrationBuilder.RenameIndex(
                name: "IX_Miembro_CargoTerritorialId",
                table: "Miembro",
                newName: "IX_Miembro_EstructuraId");

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadId",
                table: "Miembro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Miembro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_CargoId",
                table: "Miembro",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Cargo_CargoId",
                table: "Miembro",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Estructuras_EstructuraId",
                table: "Miembro",
                column: "EstructuraId",
                principalTable: "Estructuras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Localidad_LocalidadId",
                table: "Miembro",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
