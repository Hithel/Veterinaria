

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IMovimiento : IGenericRepo<Movimiento>
    {
        abstract Task<IEnumerable<Object>> GetInfoMovimientoMedicamento();
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMovimientoMedicamento(int pageIndex, int pageSize, string search);
    }
