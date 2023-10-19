

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

        public override async Task<Raza> GetByIdAsync(int id)
        {
            return await _context.Razas
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
