using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDE.Persistence.Migrations
{
    public partial class campo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "Miembro",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_LocalidadId",
                table: "Miembro",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Localidad_LocalidadId",
                table: "Miembro",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Localidad_LocalidadId",
                table: "Miembro");

            migrationBuilder.DropIndex(
                name: "IX_Miembro_LocalidadId",
                table: "Miembro");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "Miembro");
        }
    }
}
