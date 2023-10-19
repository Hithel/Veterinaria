
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
    {
        private readonly ApiContext _context;

        public MedicamentoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            return await _context.Medicamentos
                .ToListAsync();
        }

        public override async Task<Medicamento> GetByIdAsync(int id)
        {
            return await _context.Medicamentos
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
