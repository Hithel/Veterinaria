
using Domain.Entities;

namespace Domain.Interfaces;
    public interface IMedicamento : IGenericRepo<Medicamento>
    {
        Task<IEnumerable<Object>> GetInfoMedicamentoLaboratorio(string Laboratorio);
        Task<IEnumerable<Object>> GetInfoMedicamentoPrecio(double Precio);
        Task<IEnumerable<Object>> GetInfoMedicamentoProveedor(string Medicamento);
    }
