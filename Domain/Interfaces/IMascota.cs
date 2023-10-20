

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IMascota : IGenericRepo<Mascota>
    {
        abstract Task<IEnumerable<Object>> GetInfoMascotaEspecie(string Especie);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMascotaEspecie(string Especie, int pageIndex, int pageSize, string search);
        abstract Task<IEnumerable<Object>> GetAgruparMascotaEspecie();
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetAgruparMascotaEspecie( int pageIndex, int pageSize, string search);
        abstract Task<IEnumerable<Object>> GetMascotasYPropietariosporRaza(string Raza);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetMascotasYPropietariosporRaza(string Raza, int pageIndex, int pageSize, string search);
        abstract Task<IEnumerable<Object>> GetCantidadMascotasRaza();
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetCantidadMascotasRaza(int pageIndex, int pageSize, string search);
    }
