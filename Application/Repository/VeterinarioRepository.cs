

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
    {
        private readonly ApiContext _context;

        public VeterinarioRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return await _context.Veterinarios
                .ToListAsync();
        }

        public override async Task<Veterinario> GetByIdAsync(int id)
        {
            return await _context.Veterinarios
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }

        public  async Task<IEnumerable<Object>> GetEspecialidad(string Especialidad)
        {
            var result = await (
                from v in _context.Veterinarios
                where v.Especialidad.ToLower() == Especialidad.ToLower()
                select new 
                {
                    Nombre = v.Nombre,
                    Especialidad = v.Especialidad
                })
                .ToListAsync();

                return result;
        }

    public async Task<(int totalRegistros, IEnumerable<object> registros)> GetEspecialidad(string Especialidad, int pageIndex, int pageSize, string search)
    {
        var query = from v in _context.Veterinarios
                where v.Especialidad.ToLower() == Especialidad.ToLower()
                select new 
                {
                    Nombre = v.Nombre,
                    Especialidad = v.Especialidad
                };

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            }

            query = query.OrderBy(p => p.Nombre);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
    }
}
