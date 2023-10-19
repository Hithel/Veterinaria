
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class EspecieRepository : GenericRepository<Especie>, IEspecie
    {
        private readonly ApiContext _context;

        public EspecieRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Especie>> GetAllAsync()
        {
            return await _context.Especies
                .ToListAsync();
        }

        public override async Task<Especie> GetByIdAsync(int id)
        {
            return await _context.Especies
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }