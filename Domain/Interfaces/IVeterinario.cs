

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IVeterinario : IGenericRepo<Veterinario>
    {
        Task<IEnumerable<Object>> GetEspecialidad(string Especialidad);
    }
