

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
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
