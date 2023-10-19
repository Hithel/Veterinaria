
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
    }
