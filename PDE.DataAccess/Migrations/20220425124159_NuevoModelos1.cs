using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDE.DataAccess.Migrations
{
    public partial class NuevoModelos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlevaColegio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuedeVotar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlevaDatosActa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LlevaDatosPasaporte = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoColegio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idmunicipio = table.Column<short>(type: "smallint", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idrecinto = table.Column<int>(type: "int", nullable: false),
                    TieneCupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadInscritos = table.Column<int>(type: "int", nullable: true),
                    CantidadReservada = table.Column<int>(type: "int", nullable: true),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colegios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCiviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCiviles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    MunicipioPadreId = table.Column<int>(type: "int", nullable: true),
                    Oficio = table.Column<double>(type: "float", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gentilicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Siglas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocupacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiereTitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoTerritorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    LocalidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoTerritorial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoTerritorial_Cargo",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoTerritorial_Localidad",
                        column: x => x.LocalidadId,
                        principalTable: "Localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoTerritorial_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Miembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    CargoTerritorialId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: true),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: true),
                    OcupacionId = table.Column<int>(type: "int", nullable: true),
                    NacionalidadId = table.Column<int>(type: "int", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    ColegioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Miembro_CargoTerritorial_CargoTerritorialId",
                        column: x => x.CargoTerritorialId,
                        principalTable: "CargoTerritorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Miembro_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Miembro_EstadoCiviles_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCiviles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Miembro",
                        column: x => x.SupervisorId,
                        principalTable: "Miembro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Nacionalidads_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "Nacionalidads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Ocupacions_OcupacionId",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupacions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoTerritorial_CargoId",
                table: "CargoTerritorial",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoTerritorial_LocalidadId",
                table: "CargoTerritorial",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoTerritorial_SupervisorId",
                table: "CargoTerritorial",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_CargoTerritorialId",
                table: "Miembro",
                column: "CargoTerritorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_CategoriaId",
                table: "Miembro",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_EstadoCivilId",
                table: "Miembro",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_MunicipioId",
                table: "Miembro",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_NacionalidadId",
                table: "Miembro",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_OcupacionId",
                table: "Miembro",
                column: "OcupacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_SexoId",
                table: "Miembro",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_SupervisorId",
                table: "Miembro",
                column: "SupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colegios");

            migrationBuilder.DropTable(
                name: "Miembro");

            migrationBuilder.DropTable(
                name: "CargoTerritorial");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "EstadoCiviles");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Nacionalidads");

            migrationBuilder.DropTable(
                name: "Ocupacions");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Localidad");
        }
    }
}
