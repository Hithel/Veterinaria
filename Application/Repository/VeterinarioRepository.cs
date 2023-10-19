

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
    {
        private readonly ApiContext _context;

        public VeterinarioRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return await _context.Veterinarios
                .ToListAsync();
        }

        public override async Task<Veterinario> GetByIdAsync(int id)
        {
            return await _context.Veterinarios
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }