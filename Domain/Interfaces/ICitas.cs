

using Domain.Entities;

namespace Domain.Interfaces;
    public interface ICitas : IGenericRepo<Citas>
    {
        Task<IEnumerable<Object>> GetInfoMascotaMotivo(string Motivo);
        Task<IEnumerable<Object>> GetInfoMascotaVeterinarios(string Nombre);
    }
