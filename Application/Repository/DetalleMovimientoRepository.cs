

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class DetalleMovimientoRepository : GenericRepository<DetalleMovimiento>, IDetalleMovimiento
    {
        private readonly ApiContext _context;

        public DetalleMovimientoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
        {
            return await _context.DetalleMovimientos
                .ToListAsync();
        }

        public override async Task<DetalleMovimiento> GetByIdAsync(int id)
        {
            return await _context.DetalleMovimientos
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
