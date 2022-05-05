
SET IDENTITY_INSERT db_PDE01.dbo.Nacionalidads ON
insert  into db_PDE01.dbo.Nacionalidads(Id, Descripcion, Gentilicio, Estatus, Siglas, RegId)
select ID, Descripcion, Gentilicio, Estatus, Siglas, RegID from [dbPadron2024_20210917].dbo.Nacionalidad

SET IDENTITY_INSERT db_PDE01.dbo.Nacionalidads OFF
go

SET IDENTITY_INSERT db_PDE01.dbo.Ocupacions ON
insert  into db_PDE01.dbo.Ocupacions(Id, Descripcion, RequiereTitulo, Estatus, RegID)
select ID, Descripcion, RequiereTitulo, Estatus, RegID from [dbPadron2024_20210917].dbo.Ocupacion

SET IDENTITY_INSERT db_PDE01.dbo.Ocupacions OFF
go

SET IDENTITY_INSERT db_PDE01.dbo.MacroRegion ON
insert  into db_PDE01.dbo.MacroRegion(Id, Descripcion, RegID)
select ID, Descripcion, RegID from [dbPadron2024_20210917].dbo.MacroRegion

SET IDENTITY_INSERT db_PDE01.dbo.MacroRegion OFF
go

SET IDENTITY_INSERT db_PDE01.dbo.Region ON
insert  into db_PDE01.dbo.Region(Id, Descripcion, MacroRegionId)
select ID, Descripcion, IDMacroRegion from [dbPadron2024_20210917].dbo.Region

SET IDENTITY_INSERT db_PDE01.dbo.Region OFF
go

insert  into db_PDE01.dbo.Zona(Descripcion)
select  Descripcion from [dbPadron2024_20210917].dbo.Zona
go

SET IDENTITY_INSERT db_PDE01.dbo.Provincia ON
insert  into db_PDE01.dbo.Provincia(Id, Descripcion, MunicipioCabeceraId, Oficio, Estatus, ZONA, RegID, RegionId)
select ID, Descripcion, IDMunicipioCabecera, Oficio, Estatus, ZONA, RegID, Region from [dbPadron2024_20210917].dbo.Provincia

SET IDENTITY_INSERT db_PDE01.dbo.Provincia OFF


SET IDENTITY_INSERT db_PDE01.dbo.Municipio ON
insert  into db_PDE01.dbo.Municipio(Id, Descripcion, ProvinciaId, MunicipioPadreId, Oficio, Estatus, DM, RegID)
select ID, Descripcion, IDProvincia, IDMunicipioPadre, Oficio, Estatus,DM , RegID from [dbPadron2024_20210917].dbo.Municipio
SET IDENTITY_INSERT db_PDE01.dbo.Municipio OFF
go

SET IDENTITY_INSERT db_PDE01.dbo.Circunscripcion ON
insert  into db_PDE01.dbo.Circunscripcion(Id, Descripcion, ProvinciaId, CodigoCircunscripcion, RegID)
select ID, Descripcion, IDProvincia, CodigoCircunscripcion, RegID from [dbPadron2024_20210917].dbo.Circunscripcion

SET IDENTITY_INSERT db_PDE01.dbo.Circunscripcion OFF
go


SET IDENTITY_INSERT db_PDE01.dbo.CiudadSeccion ON
insert  into db_PDE01.dbo.CiudadSeccion(Id, Descripcion, MunicipioId, DistritoMunicipalId, CodigoCiudad, Oficio, Estatus, RegID)
select ID, Descripcion, IDMunicipio, IDDistritoMunicipal, CodigoCiudad, Oficio, Estatus, RegID from [dbPadron2024_20210917].dbo.CiudadSeccion

SET IDENTITY_INSERT db_PDE01.dbo.CiudadSeccion OFF
go

SET IDENTITY_INSERT db_PDE01.dbo.SectorParaje ON
insert  into db_PDE01.dbo.SectorParaje(Id, Descripcion, CiudadSeccionId, CodigoSector, Oficio, Estatus, RegID)
select ID, Descripcion, IDCiudadSeccion, CodigoSector, Oficio, Estatus, RegID from [dbPadron2024_20210917].dbo.SectorParaje

SET IDENTITY_INSERT db_PDE01.dbo.SectorParaje OFF
go

SET IDENTITY_INSERT db_PDE01.dbo.Recinto ON
insert  into db_PDE01.dbo.Recinto(Id, CodigoRecinto, Descripcion, Direccion, SectorParajeId, CircunscripcionId, BarrioId, CapacidadRecinto, Oficio,
Estatus, DescripcionLarga, DireccionLarga, Tipo, Codigo, RegID)
select ID, CodigoRecinto, Descripcion,Direccion, IDSectorParaje, IDCircunscripcion, IDBarrio, CapacidadRecinto, Oficio,
Estatus, DescripcionLarga, DireccionLarga, Tipo, Codigo, RegID from [dbPadron2024_20210917].dbo.Recinto

SET IDENTITY_INSERT db_PDE01.dbo.Recinto OFF
go

SET IDENTITY_INSERT db_PDE01.dbo.Colegios ON
insert  into db_PDE01.dbo.Colegios(Id, CodigoColegio, MunicipioId, Descripcion, RecintoId, TieneCupo, CantidadInscritos, CantidadReservada, RegId)
select IDColegio, CodigoColegio, IDMunicipio, Descripcion, IDRecinto, TieneCupo, CantidadInscritos, CantidadReservada, RegID
from [dbPadron2024_20210917].dbo.Colegio

SET IDENTITY_INSERT db_PDE01.dbo.Colegios OFF



insert  into db_PDE01.dbo.Sexo(Descripcion, IdUsuarioCreacion, FechaCreacion, IdUsuarioModificacion, FechaModificacion, RegId)
select  Descripcion, IdUsuarioCreacion, FechaCreacion, IdUsuarioModificacion, FechaModificacion, RegID from [dbPadron2024_20210917].dbo.Sexo


SET IDENTITY_INSERT db_PDE01.dbo.Categorias ON
insert  into db_PDE01.dbo.Categorias(Id, Descripcion, LlevaColegio, PuedeVotar, LlevaDatosActa, LlevaDatosPasaporte)
select ID, Descripcion, LlevaColegio, PuedeVotar, LlevaDatosActa, LlevaDatosPasaporte
from [dbPadron2024_20210917].dbo.Categoria

SET IDENTITY_INSERT db_PDE01.dbo.Categorias OFF



insert  into db_PDE01.dbo.EstadoCiviles(Descripcion, RegId)
select Descripcion, RegID
from [dbPadron2024_20210917].dbo.EstadoCivil



SET IDENTITY_INSERT db_PDE01.dbo.Miembro ON
insert  into db_PDE01.dbo.Miembro(Id, Nombres, Apellidos, Cedula, FechaNacimiento, LugarNacimiento, Celular,
SupervisorId, CargoId, CategoriaId, SexoId, EstadoCivilId, OcupacionId, NacionalidadId, MunicipioId, ColegioId)
select Id, Nombres, Apellidos, Cedula, FechaNacimiento, LugarNacimiento, Celular, SupervisorId, CargoId, CategoriaId,
SexoId, EstadoCivilId, OcupacionId, NacionalidadId, MunicipioId, ColegioId
from dbPDE01.dbo.Miembro

SET IDENTITY_INSERT db_PDE01.dbo.Miembro OFF