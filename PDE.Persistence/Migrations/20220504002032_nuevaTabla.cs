using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDE.Persistence.Migrations
{
    public partial class nuevaTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                name: "EstadoCiviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCiviles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estructuras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estructuras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MacroRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RegID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacroRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gentilicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Zona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoTerritorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    CargoSupervisorId = table.Column<int>(type: "int", nullable: true),
                    LocalidadId = table.Column<int>(type: "int", nullable: false),
                    EstructuraId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_CargoTerritorial_Estructuras_EstructuraId",
                        column: x => x.EstructuraId,
                        principalTable: "Estructuras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoTerritorial_Localidad",
                        column: x => x.LocalidadId,
                        principalTable: "Localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoTerritorial_SupervisorId",
                        column: x => x.CargoSupervisorId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MacroRegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_MacroRegion",
                        column: x => x.MacroRegionId,
                        principalTable: "MacroRegion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    MunicipioCabeceraId = table.Column<int>(type: "int", nullable: true),
                    Oficio = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    ZONA = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    RegID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincia_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Circunscripcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    CodigoCircunscripcion = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RegID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circunscripcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circunscripcion_Provincia",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    MunicipioPadreId = table.Column<int>(type: "int", nullable: true),
                    Oficio = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Estatus = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    DM = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    RegID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Provincia",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CiudadSeccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    DistritoMunicipalId = table.Column<int>(type: "int", nullable: true),
                    CodigoCiudad = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Oficio = table.Column<long>(type: "bigint", nullable: true),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    RegID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiudadSeccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CiudadSeccion_Municipio",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectorParaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiudadSeccionId = table.Column<int>(type: "int", nullable: false),
                    CodigoSector = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    Oficio = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    RegID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorParaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorParaje_CiudadSeccion",
                        column: x => x.CiudadSeccionId,
                        principalTable: "CiudadSeccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recinto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRecinto = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    SectorParajeId = table.Column<int>(type: "int", nullable: true),
                    CircunscripcionId = table.Column<int>(type: "int", nullable: true),
                    BarrioId = table.Column<int>(type: "int", nullable: true),
                    CapacidadRecinto = table.Column<int>(type: "int", nullable: true),
                    Oficio = table.Column<int>(type: "int", nullable: true),
                    Estatus = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    DescripcionLarga = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DireccionLarga = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Tipo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Codigo = table.Column<short>(type: "smallint", nullable: true),
                    RegID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recinto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recinto_Circunscripcion",
                        column: x => x.CircunscripcionId,
                        principalTable: "Circunscripcion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recinto_SectorParaje",
                        column: x => x.SectorParajeId,
                        principalTable: "SectorParaje",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Colegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoColegio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecintoId = table.Column<int>(type: "int", nullable: false),
                    TieneCupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadInscritos = table.Column<int>(type: "int", nullable: true),
                    CantidadReservada = table.Column<int>(type: "int", nullable: true),
                    RegId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colegios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colegios_Municipio",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Colegios_Recinto",
                        column: x => x.RecintoId,
                        principalTable: "Recinto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Miembro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Miembro_Cargo",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Categorias",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Colegios",
                        column: x => x.ColegioId,
                        principalTable: "Colegios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_EstadoCiviles",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCiviles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Miembro",
                        column: x => x.SupervisorId,
                        principalTable: "Miembro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Municipio",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Nacionalidads",
                        column: x => x.NacionalidadId,
                        principalTable: "Nacionalidads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Ocupacions",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupacions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Miembro_Sexo",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoTerritorial_CargoId",
                table: "CargoTerritorial",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoTerritorial_CargoSupervisorId",
                table: "CargoTerritorial",
                column: "CargoSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoTerritorial_EstructuraId",
                table: "CargoTerritorial",
                column: "EstructuraId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoTerritorial_LocalidadId",
                table: "CargoTerritorial",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Circunscripcion_ProvinciaId",
                table: "Circunscripcion",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_CiudadSeccion_MunicipioId",
                table: "CiudadSeccion",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Colegios_MunicipioId",
                table: "Colegios",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Colegios_RecintoId",
                table: "Colegios",
                column: "RecintoId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_CargoId",
                table: "Miembro",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_CategoriaId",
                table: "Miembro",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_ColegioId",
                table: "Miembro",
                column: "ColegioId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_ProvinciaId",
                table: "Municipio",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_RegionId",
                table: "Provincia",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recinto_CircunscripcionId",
                table: "Recinto",
                column: "CircunscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recinto_SectorParajeId",
                table: "Recinto",
                column: "SectorParajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_MacroRegionId",
                table: "Region",
                column: "MacroRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorParaje_CiudadSeccionId",
                table: "SectorParaje",
                column: "CiudadSeccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoTerritorial");

            migrationBuilder.DropTable(
                name: "Miembro");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropTable(
                name: "Estructuras");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Colegios");

            migrationBuilder.DropTable(
                name: "EstadoCiviles");

            migrationBuilder.DropTable(
                name: "Nacionalidads");

            migrationBuilder.DropTable(
                name: "Ocupacions");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "Recinto");

            migrationBuilder.DropTable(
                name: "Circunscripcion");

            migrationBuilder.DropTable(
                name: "SectorParaje");

            migrationBuilder.DropTable(
                name: "CiudadSeccion");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "MacroRegion");
        }
    }
}
