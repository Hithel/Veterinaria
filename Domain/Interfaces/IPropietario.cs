

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IPropietario : IGenericRepo<Propietario>
    {
        abstract Task<IEnumerable<Object>> GetInfoPropietariosMascotas();
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoPropietariosMascotas( int pageIndex, int pageSize, string search);

    }
