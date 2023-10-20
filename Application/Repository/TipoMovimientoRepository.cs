

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimiento
{
    private readonly ApiContext _context;

    public TipoMovimientoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync()
    {
        return await _context.TipoMovimientos
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoMovimiento> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.TipoMovimientos as IQueryable<TipoMovimiento>;

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

    public override async Task<TipoMovimiento> GetByIdAsync(int id)
    {
        return await _context.TipoMovimientos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
