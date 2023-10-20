

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class RazaRepository : GenericRepository<Raza>, IRaza
{
    private readonly ApiContext _context;

    public RazaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _context.Razas
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Razas as IQueryable<Raza>;

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

    public override async Task<Raza> GetByIdAsync(int id)
    {
        return await _context.Razas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
