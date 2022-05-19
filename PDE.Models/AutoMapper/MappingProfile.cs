using AutoMapper;
using PDE.Models.Dto;
using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.AutoMapper
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Miembro, MiembroDto>();
            CreateMap<MiembroDto, Miembro>();

            CreateMap<CargoTerritorial, CargoTerritorialDto>();
            CreateMap<CargoTerritorialDto, CargoTerritorial>();

            CreateMap<Localidad, LocalidadDto>();
            CreateMap<LocalidadDto, Localidad>();

            CreateMap<Estructura, EstructuraDto>();
            CreateMap<EstructuraDto, Estructura>();

            CreateMap<Cargo, CargoDto>();
            CreateMap<CargoDto, Cargo>();
        }
    }
}
