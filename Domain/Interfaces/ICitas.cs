

using Domain.Entities;

namespace Domain.Interfaces;
    public interface ICitas : IGenericRepo<Citas>
    {
        abstract Task<IEnumerable<Object>> GetInfoMascotaMotivo(string Motivo);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMascotaMotivo(string Motivo, int pageIndex, int pageSize, string search);
        abstract Task<IEnumerable<Object>> GetInfoMascotaVeterinarios(string Nombre);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMascotaVeterinarios(string Nombre, int pageIndex, int pageSize, string search);
    }
