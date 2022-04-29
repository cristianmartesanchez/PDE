


SET IDENTITY_INSERT [dbPDE01].dbo.Ocupacions ON
insert  into [dbPDE01].dbo.Ocupacions(Id, Descripcion, RequiereTitulo, Estatus, RegID)
select ID, Descripcion, RequiereTitulo, Estatus, RegID from [dbPadron2024_20210917].dbo.Ocupacion

SET IDENTITY_INSERT [dbPDE01].dbo.Ocupacions OFF


SET IDENTITY_INSERT [dbPDE01].dbo.Region ON
insert  into [dbPDE01].dbo.Region(Id, Descripcion, MacroRegionId)
select ID, Descripcion, IDMacroRegion from [dbPadron2024_20210917].dbo.Region

SET IDENTITY_INSERT [dbPDE01].dbo.Region OFF


insert  into [dbPDE01].dbo.Zona(Descripcion)
select  Descripcion from [dbPadron2024_20210917].dbo.Zona


SET IDENTITY_INSERT [dbPDE01].dbo.Provincia ON
insert  into [dbPDE01].dbo.Provincia(Id, Descripcion, MunicipioCabeceraId, Oficio, Estatus, ZONA, RegID, RegionId)
select ID, Descripcion, IDMunicipioCabecera, Oficio, Estatus, ZONA, RegID, Region from [dbPadron2024_20210917].dbo.Provincia

SET IDENTITY_INSERT [dbPDE01].dbo.Provincia OFF


SET IDENTITY_INSERT [dbPDE01].dbo.Municipio ON
insert  into [dbPDE01].dbo.Municipio(Id, Descripcion, ProvinciaId, MunicipioPadreId, Oficio, Estatus, DM, RegID)
select ID, Descripcion, IDProvincia, IDMunicipioPadre, Oficio, Estatus,DM , RegID from [dbPadron2024_20210917].dbo.Municipio

SET IDENTITY_INSERT [dbPDE01].dbo.Municipio OFF


SET IDENTITY_INSERT [dbPDE01].dbo.Circunscripcion ON
insert  into [dbPDE01].dbo.Circunscripcion(Id, Descripcion, ProvinciaId, CodigoCircunscripcion, RegID)
select ID, Descripcion, IDProvincia, CodigoCircunscripcion, RegID from [dbPadron2024_20210917].dbo.Circunscripcion

SET IDENTITY_INSERT [dbPDE01].dbo.Circunscripcion OFF



SET IDENTITY_INSERT [dbPDE01].dbo.Circunscripcion ON
insert  into [dbPDE01].dbo.Circunscripcion(Id, Descripcion, ProvinciaId, CodigoCircunscripcion, RegID)
select ID, Descripcion, IDProvincia, CodigoCircunscripcion, RegID from [dbPadron2024_20210917].dbo.Circunscripcion

SET IDENTITY_INSERT [dbPDE01].dbo.Circunscripcion OFF


SET IDENTITY_INSERT [dbPDE01].dbo.CiudadSeccion ON
insert  into [dbPDE01].dbo.CiudadSeccion(Id, Descripcion, MunicipioId, DistritoMunicipalId, CodigoCiudad, Oficio, Estatus, RegID)
select ID, Descripcion, IDMunicipio, IDDistritoMunicipal, CodigoCiudad, Oficio, Estatus, RegID from [dbPadron2024_20210917].dbo.CiudadSeccion

SET IDENTITY_INSERT [dbPDE01].dbo.CiudadSeccion OFF


SET IDENTITY_INSERT [dbPDE01].dbo.SectorParaje ON
insert  into [dbPDE01].dbo.SectorParaje(Id, Descripcion, CiudadSeccionId, CodigoSector, Oficio, Estatus, RegID)
select ID, Descripcion, IDCiudadSeccion, CodigoSector, Oficio, Estatus, RegID from [dbPadron2024_20210917].dbo.SectorParaje

SET IDENTITY_INSERT [dbPDE01].dbo.SectorParaje OFF


SET IDENTITY_INSERT [dbPDE01].dbo.Recinto ON
insert  into [dbPDE01].dbo.Recinto(Id, CodigoRecinto, Descripcion, Direccion, SectorParajeId, CircunscripcionId, BarrioId, CapacidadRecinto, Oficio,
Estatus, DescripcionLarga, DireccionLarga, Tipo, Codigo, RegID)
select ID, CodigoRecinto, Descripcion,Direccion, IDSectorParaje, IDCircunscripcion, IDBarrio, CapacidadRecinto, Oficio,
Estatus, DescripcionLarga, DireccionLarga, Tipo, Codigo, RegID from [dbPadron2024_20210917].dbo.Recinto

SET IDENTITY_INSERT [dbPDE01].dbo.Recinto OFF


SET IDENTITY_INSERT [dbPDE01].dbo.Colegios ON
insert  into [dbPDE01].dbo.Colegios(Id, CodigoColegio, MunicipioId, Descripcion, RecintoId, TieneCupo, CantidadInscritos, CantidadReservada, RegId)
select IDColegio, CodigoColegio, IDMunicipio, Descripcion, IDRecinto, TieneCupo, CantidadInscritos, CantidadReservada, RegID
from [dbPadron2024_20210917].dbo.Colegio

SET IDENTITY_INSERT [dbPDE01].dbo.Colegios OFF