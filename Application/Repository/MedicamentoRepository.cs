
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

        public async Task<IEnumerable<Object>> GetInfoMedicamentoLaboratorio(string Laboratorio)
        {
            var result = await (
                from m in _context.Medicamentos
                join l in _context.Laboratorios on m.IdLaboratorioFk equals l.Id
                where l.Nombre.ToLower() == Laboratorio.ToLower()
                select new 
                {
                    Nombre = m.Nombre,
                    Laboratorio = l.Nombre
                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Object>> GetInfoMedicamentoPrecio(double Precio)
        {
            var result = await (
                from m in _context.Medicamentos
                where m.Precio > Precio
                select new 
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Precio = m.Precio
                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Object>> GetInfoMedicamentoProveedor(string Medicamento)
        {
            var result = await (
                from mp in _context.MedicamentoProveedores
            where mp.Medicamento.Nombre.ToLower() == Medicamento.ToLower() 
            select new 
            {
                IdProveedor = mp.Proveedor.Id,
                Proveedor = mp.Proveedor.Nombre
            }).ToListAsync();
                

            return result;
        }
    }
