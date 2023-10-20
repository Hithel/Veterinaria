

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class MovimientoRepository : GenericRepository<Movimiento>, IMovimiento
{
    private readonly ApiContext _context;

    public MovimientoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Movimiento>> GetAllAsync()
    {
        return await _context.Movimientos
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Movimiento> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Movimientos as IQueryable<Movimiento>;

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

    public override async Task<Movimiento> GetByIdAsync(int id)
    {
        return await _context.Movimientos
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> GetInfoMovimientoMedicamento()
    {
        var result = await (
            from dm in _context.DetalleMovimientos
            join m in _context.Movimientos on dm.IdMovimientoFK equals m.Id
            join med in _context.Medicamentos on dm.IdMedicamentoFk equals med.Id
            select new
            {
                Id = med.Id,
                Nombre = med.Nombre,
                Cantidad = med.Cantidad,
                PrecioUnidad = dm.PrecioUnitario,
                PrecioTotal = m.PrecioTotal
            }).ToListAsync();

        return result;
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMovimientoMedicamento(int pageIndex, int pageSize, string search)
    {
        var query = from dm in _context.DetalleMovimientos
            join m in _context.Movimientos on dm.IdMovimientoFK equals m.Id
            join med in _context.Medicamentos on dm.IdMedicamentoFk equals med.Id
            select new
            {
                Id = med.Id,
                Nombre = med.Nombre,
                Cantidad = med.Cantidad,
                PrecioUnidad = dm.PrecioUnitario,
                PrecioTotal = m.PrecioTotal
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
