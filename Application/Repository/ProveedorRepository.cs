

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
        private readonly ApiContext _context;

        public ProveedorRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores
                .ToListAsync();
        }

        public override async Task<Proveedor> GetByIdAsync(int id)
        {
            return await _context.Proveedores
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }