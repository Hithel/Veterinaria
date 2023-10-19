

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

        public override async Task<Movimiento> GetByIdAsync(int id)
        {
            return await _context.Movimientos
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
