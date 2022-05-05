using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDE.Persistence.Migrations
{
    public partial class removeCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Cargo",
                table: "Miembro");

            migrationBuilder.RenameColumn(
                name: "CargoId",
                table: "Miembro",
                newName: "CargoTerritorialId");

            migrationBuilder.RenameIndex(
                name: "IX_Miembro_CargoId",
                table: "Miembro",
                newName: "IX_Miembro_CargoTerritorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_CargoTerritorial_CargoTerritorialId",
                table: "Miembro",
                column: "CargoTerritorialId",
                principalTable: "CargoTerritorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_CargoTerritorial_CargoTerritorialId",
                table: "Miembro");

            migrationBuilder.RenameColumn(
                name: "CargoTerritorialId",
                table: "Miembro",
                newName: "CargoId");

            migrationBuilder.RenameIndex(
                name: "IX_Miembro_CargoTerritorialId",
                table: "Miembro",
                newName: "IX_Miembro_CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Cargo",
                table: "Miembro",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id");
        }
    }
}
