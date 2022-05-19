using PDE.Models.Dto;
using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Interfaces
{
    public interface IMiembrosRepository : IGenericRepository<Miembro>
    {
        Task<MiembroDto> GetMiembroByCedula(string cedula);
        IQueryable<MiembroDto> GetMiembros();
        bool MiembroExists(string cedula);
        IQueryable<MiembroDto> GetMiembrosBySupervisor(int supervisorId);
        Task<IEnumerable<MiembroDto>> GetMiembrosByCargo(int cargoId);
        Task<IEnumerable<MiembroDto>> GetSupervisorByCargo(int CargoId, int LocalidadId);
    }
}
