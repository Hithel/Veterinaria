

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IPropietario : IGenericRepo<Propietario>
    {
        Task<IEnumerable<Object>> GetInfoPropietariosMascotas();
    }
