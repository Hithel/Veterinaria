

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class TratamientoMedicoRepository : GenericRepository<TratamientoMedico>, ITratamientoMedico
    {
        private readonly ApiContext _context;

        public TratamientoMedicoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<TratamientoMedico>> GetAllAsync()
        {
            return await _context.TratamientoMedicos
                .ToListAsync();
        }

        public override async Task<TratamientoMedico> GetByIdAsync(int id)
        {
            return await _context.TratamientoMedicos
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
