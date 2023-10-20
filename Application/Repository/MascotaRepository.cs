
using System.Security.Cryptography;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class MascotaRepository : GenericRepository<Mascota>, IMascota
{
    private readonly ApiContext _context;

    public MascotaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Mascotas as IQueryable<Mascota>;

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

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> GetInfoMascotaEspecie(string Especie)
    {
        var result = await (
            from m in _context.Mascotas
            join r in _context.Razas on m.IdRazaFK equals r.Id
            join e in _context.Especies on r.IdEspecieFK equals e.Id
            where e.Descripcion.ToLower() == Especie.ToLower()
            select new
            {
                Nombre = m.Nombre,
                Raza = r.Descripcion,
                Especie = e.Descripcion
            }).ToArrayAsync();

        return result;
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMascotaEspecie(string Especie, int pageIndex, int pageSize, string search)
    {
        var query = from m in _context.Mascotas
            join r in _context.Razas on m.IdRazaFK equals r.Id
            join e in _context.Especies on r.IdEspecieFK equals e.Id
            where e.Descripcion.ToLower() == Especie.ToLower()
            select new
            {
                Nombre = m.Nombre,
                Raza = r.Descripcion,
                Especie = e.Descripcion
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

    public async Task<IEnumerable<Object>> GetAgruparMascotaEspecie()
    {
        return await (
            from e in _context.Especies
            select new
            {
                NameSpecies = e.Descripcion,
                Pets = (
                    from pet in _context.Mascotas
                    join raza in _context.Razas on pet.IdRazaFK equals raza.Id
                    where raza.IdEspecieFK == e.Id
                    select new
                    {
                        Name = pet.Nombre,
                        Especies = e.Descripcion
                    }
                ).ToList()
            }
        ).ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetAgruparMascotaEspecie( int pageIndex, int pageSize, string search)
    {
        var query = from e in _context.Especies
            select new
            {
                Especie = e.Descripcion,
                Pets = (
                    from pet in _context.Mascotas
                    join raza in _context.Razas on pet.IdRazaFK equals raza.Id
                    where raza.IdEspecieFK == e.Id
                    select new
                    {
                        Name = pet.Nombre,
                        Especies = e.Descripcion
                    }
                ).ToList()
            };

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Especie.Equals(search));
            }

            query = query.OrderBy(p => p.Especie);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
    }


    public async Task<IEnumerable<Object>> GetMascotasYPropietariosporRaza(string Raza)
    {
        var result = await (
            from e in _context.Mascotas
            join p in _context.Propietarios on e.IdPropietarioFk equals p.Id
            join br in _context.Razas on e.IdRazaFK equals br.Id
            where br.Descripcion.ToLower() == Raza.ToLower()
            select new
            {
                Nombre = e.Nombre,
                Propietario = p.Nombre
            }).ToListAsync();

        return result;
    }


    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetMascotasYPropietariosporRaza(string Raza, int pageIndex, int pageSize, string search)
    {
        var query = from e in _context.Mascotas
            join p in _context.Propietarios on e.IdPropietarioFk equals p.Id
            join br in _context.Razas on e.IdRazaFK equals br.Id
            where br.Descripcion.ToLower() == Raza.ToLower()
            select new
            {
                Nombre = e.Nombre,
                Propietario = p.Nombre
            };

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.Equals(search));
        }

            query = query.OrderBy(p => p.Nombre);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);      
    }

    public async Task<IEnumerable<Object>> GetCantidadMascotasRaza()
    {
        return await (
            from br in _context.Razas
            where (
                from pe in _context.Mascotas
                where pe.IdRazaFK == br.Id
                select pe
            ).Any()
            select new
            {
                NameBreed = br.Descripcion,
                Mascota = (
                    from p in _context.Mascotas
                    where p.IdRazaFK.Equals(br.Id)
                    select new
                    {
                        Nombre = p.Nombre
                    }
                ).ToList()
            }
        ).ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetCantidadMascotasRaza(int pageIndex, int pageSize, string search)
    {
        var query = from br in _context.Razas
            where (
                from pe in _context.Mascotas
                where pe.IdRazaFK == br.Id
                select pe
            ).Any()
            select new
            {
                Raza = br.Descripcion,
                Mascota = (
                    from p in _context.Mascotas
                    where p.IdRazaFK.Equals(br.Id)
                    select new
                    {
                        Nombre = p.Nombre
                    }
                ).ToList()
            };

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Raza.Equals(search));
            }

            query = query.OrderBy(p => p.Raza);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);

    }
}
