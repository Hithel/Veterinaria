
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly ApiContext _context;

    public MedicamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Medicamentos as IQueryable<Medicamento>;

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

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> GetInfoMedicamentoLaboratorio(string Laboratorio)
    {
        var result = await (
            from m in _context.Medicamentos
            join l in _context.Laboratorios on m.IdLaboratorioFk equals l.Id
            where l.Nombre.ToLower() == Laboratorio.ToLower()
            select new
            {
                Nombre = m.Nombre,
                Laboratorio = l.Nombre
            }).ToListAsync();

        return result;
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMedicamentoLaboratorio(string Laboratorio, int pageIndex, int pageSize, string search)
    {
        var query = from m in _context.Medicamentos
            join l in _context.Laboratorios on m.IdLaboratorioFk equals l.Id
            where l.Nombre.ToLower() == Laboratorio.ToLower()
            select new
            {
                Nombre = m.Nombre,
                Laboratorio = l.Nombre
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

    public async Task<IEnumerable<Object>> GetInfoMedicamentoPrecio(double Precio)
    {
        var result = await (
            from m in _context.Medicamentos
            where m.Precio > Precio
            select new
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Precio = m.Precio
            }).ToListAsync();

        return result;
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMedicamentoPrecio(double Precio, int pageIndex, int pageSize, string search)
    {
        var query = from m in _context.Medicamentos
            where m.Precio > Precio
            select new
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Precio = m.Precio
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

    public async Task<IEnumerable<Object>> GetInfoMedicamentoProveedor(string Medicamento)
    {
        var result = await (
            from p in _context.Proveedores
            join mp in _context.MedicamentoProveedores on p.Id equals mp.IdProveedorFk
            join med in _context.Medicamentos on mp.IdMedicamentoFk equals med.Id
            where (
                from MedP in _context.MedicamentoProveedores
                where MedP.IdProveedorFk == p.Id
                select MedP
            ).Any()
            select new
            {
                Name = p.Nombre
            }).ToListAsync();


        return result;
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMedicamentoProveedor(string Medicamento, int pageIndex, int pageSize, string search)
    {
        var query = from p in _context.Proveedores
            join mp in _context.MedicamentoProveedores on p.Id equals mp.IdProveedorFk
            join med in _context.Medicamentos on mp.IdMedicamentoFk equals med.Id
            where (
                from MedP in _context.MedicamentoProveedores
                where MedP.IdProveedorFk == p.Id
                select MedP
            ).Any()
            select new
            {
                Nombre = p.Nombre
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
