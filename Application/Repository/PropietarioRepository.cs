

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PropietarioRepository : GenericRepository<Propietario>, IPropietario
{
    private readonly ApiContext _context;

    public PropietarioRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Propietario> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Propietarios as IQueryable<Propietario>;

        if (!string.IsNullOrEmpty(search.ToString()))
        {
            query = query.Where(p => p.Id.Equals(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Propietarios
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> GetInfoPropietariosMascotas()
    {
        var result = await (
            from p in _context.Propietarios
            join m in _context.Mascotas on p.Id equals m.IdPropietarioFk
            select new
            {
                Propietario = p.Nombre,
                Mascotas = m.Nombre
            }
        ).ToListAsync();

        return result;
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoPropietariosMascotas( int pageIndex, int pageSize, string search)
    {
        var query = from p in _context.Propietarios
            join m in _context.Mascotas on p.Id equals m.IdPropietarioFk
            select new
            {
                Propietario = p.Nombre,
                Mascotas = m.Nombre
            };

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Propietario.ToLower().Contains(search));
            }

            query = query.OrderBy(p => p.Propietario);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
    }
}
