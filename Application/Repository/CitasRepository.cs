

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class CitasRepository : GenericRepository<Citas>, ICitas
{
    private readonly ApiContext _context;

    public CitasRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Citas>> GetAllAsync()
    {
        return await _context.Citas
            .ToListAsync();
    }

    public override async Task<Citas> GetByIdAsync(int id)
    {
        return await _context.Citas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Citas> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Citas as IQueryable<Citas>;

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

    public async Task<IEnumerable<Object>> GetInfoMascotaMotivo(string Motivo)
    {

        int year = 2023;
        DateTime primerTrimestreInicio = new DateTime(year, 1, 1);
        DateTime primerTrimestreFin = new DateTime(year, 3, 31);

        var result = await (
            from c in _context.Citas
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id

            where c.Motivo == Motivo &&
            c.Fecha >= primerTrimestreInicio && c.Fecha <= primerTrimestreFin

            select new
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Motivo = c.Motivo
            }).ToListAsync();

        return result;
    }


    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMascotaMotivo(string Motivo, int pageIndex, int pageSize, string search)
    {

        int year = 2023;
        DateTime primerTrimestreInicio = new DateTime(year, 1, 1);
        DateTime primerTrimestreFin = new DateTime(year, 3, 31);

        var query = from c in _context.Citas
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id

            where c.Motivo == Motivo &&
            c.Fecha >= primerTrimestreInicio && c.Fecha <= primerTrimestreFin

            select new
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Motivo = c.Motivo
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

    public async Task<IEnumerable<Object>> GetInfoMascotaVeterinarios(string Nombre)
    {
        var result = await (
            from c in _context.Citas
            join v in _context.Veterinarios on c.IdVeterinarioFK equals v.Id
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id
            where v.Nombre.ToLower() == Nombre.ToLower()
            select new
            {
                Veterinario = v.Nombre,
                IdMascota = m.Id,
                Nombre = m.Nombre,

            }).ToListAsync();

        return result;
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMascotaVeterinarios(string Nombre, int pageIndex, int pageSize, string search)
    {
        var query = from c in _context.Citas
            join v in _context.Veterinarios on c.IdVeterinarioFK equals v.Id
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id
            where v.Nombre.ToLower() == Nombre.ToLower()
            select new
            {
                Veterinario = v.Nombre,
                IdMascota = m.Id,
                Nombre = m.Nombre,

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
