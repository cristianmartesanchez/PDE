using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDE.Persistence.Migrations
{
    public partial class campos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ZONA",
                table: "Provincia",
                type: "int",
                unicode: false,
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldUnicode: false,
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_RegionId",
                table: "Provincia",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provincia_Region_RegionId",
                table: "Provincia",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provincia_Region_RegionId",
                table: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_Provincia_RegionId",
                table: "Provincia");

            migrationBuilder.AlterColumn<string>(
                name: "ZONA",
                table: "Provincia",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 2,
                oldNullable: true);
        }
    }
}
