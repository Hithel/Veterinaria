

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IVeterinario : IGenericRepo<Veterinario>
    {
        abstract Task<IEnumerable<Object>> GetEspecialidad(string Especialidad);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetEspecialidad(string Especialidad, int pageIndex, int pageSize, string search);
    }
