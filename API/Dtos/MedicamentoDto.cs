

using Domain.Entities;

namespace API.Dtos;
    public class MedicamentoDto : BaseEntity
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int IdLaboratorioFk { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public List<TratamientoMedicoDto> TratamientoMedicos { get; set; }
        public List<DetalleMovimientoDto> DetalleMovimientos{ get; set; }
        public List<ProveedorDto> Proveedores { get; set; }
    }
