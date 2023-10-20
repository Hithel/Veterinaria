
using Domain.Entities;

namespace Domain.Interfaces;
    public interface IMedicamento : IGenericRepo<Medicamento>
    {
        abstract Task<IEnumerable<Object>> GetInfoMedicamentoLaboratorio(string Laboratorio);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMedicamentoLaboratorio(string Laboratorio, int pageIndex, int pageSize, string search);


        abstract Task<IEnumerable<Object>> GetInfoMedicamentoPrecio(double Precio);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMedicamentoPrecio(double Precio, int pageIndex, int pageSize, string search);
        abstract Task<IEnumerable<Object>> GetInfoMedicamentoProveedor(string Medicamento);
        abstract Task<(int totalRegistros, IEnumerable<Object> registros)> GetInfoMedicamentoProveedor(string Medicamento, int pageIndex, int pageSize, string search);
    }
