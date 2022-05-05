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
        Task<Miembro> GetMiembroByCedula(string cedula);
        IQueryable<Miembro> GetMiembros();
        bool MiembroExists(string cedula);
        IQueryable<Miembro> GetMiembrosBySupervisor(int supervisorId);
        Task<IEnumerable<Miembro>> GetMiembrosByCargo(int cargoId);
        Task<IEnumerable<Miembro>> GetSupervisorByCargo(int CargoId, int LocalidadId);
    }
}
