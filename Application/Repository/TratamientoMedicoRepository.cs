

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class TratamientoMedicoRepository : GenericRepository<TratamientoMedico>, ITratamientoMedico
{
    private readonly ApiContext _context;

    public TratamientoMedicoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<TratamientoMedico>> GetAllAsync()
    {
        return await _context.TratamientoMedicos
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<TratamientoMedico> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.TratamientoMedicos as IQueryable<TratamientoMedico>;

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

    public override async Task<TratamientoMedico> GetByIdAsync(int id)
    {
        return await _context.TratamientoMedicos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
