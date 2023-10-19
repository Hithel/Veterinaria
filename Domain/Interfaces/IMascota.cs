

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IMascota : IGenericRepo<Mascota>
    {
        Task<IEnumerable<Object>> GetInfoMascotaEspecie(string Especie);
        Task<IEnumerable<Object>> GetAgruparMascotaEspecie();
        Task<IEnumerable<Object>> GetMascotasYPropietariosporRaza(string Raza);
        Task<IEnumerable<Object>> GetCantidadMascotasRaza();
    }
