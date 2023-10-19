
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

        public override async Task<Mascota> GetByIdAsync(int id)
        {
            return await _context.Mascotas
            .FirstOrDefaultAsync(p =>  p.Id == id);
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

        public async Task<IEnumerable<Object>> GetAgruparMascotaEspecie()
        {
            var query = _context.Mascotas
                .Join(_context.Razas, ma => ma.IdRazaFK, r => r.Id, (ma, r) => new { Mascota = ma, Raza = r })
                .GroupBy(x => x.Raza.Especie)
                .Select(especiesGroup => new
                {
                    Especie = especiesGroup.Key,
                    Mascotas = especiesGroup.Select(x => new
                    {
                        Id = x.Mascota.Id,
                        Nombre = x.Mascota.Nombre,
                        Especie = x.Raza.Especie.Descripcion
                    }).ToList()
                });

            return await query.ToListAsync();

        } 


        public async Task<IEnumerable<Object>> GetMascotasYPropietariosporRaza(string Raza)
        {
            var result = await (
                from m in _context.Mascotas
                join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
                where m.Raza.Descripcion.ToLower() == Raza.ToLower()
                select new 
                {
                    Propietario = p.Nombre,
                    Mascota = m.Nombre
                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Object>> GetCantidadMascotasRaza()
        {
            var result = await _context.Mascotas
            .GroupBy(m => m.IdRazaFK)
            .Select(g => new 
            {
                IdRaza = g.Key,
                Cantidad = g.Count()
            })
            .ToListAsync();

        var razas = await _context.Razas
            .ToDictionaryAsync(r => r.Id, r => r.Descripcion);

        var resultado = result
            .Select(m => new 
            {
                Raza = razas[m.IdRaza],
                CantidadMascotas = m.Cantidad
            })
            .ToList();

        return result;
        }
    }
