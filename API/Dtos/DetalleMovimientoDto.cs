

using Domain.Entities;

namespace API.Dtos;
    public class DetalleMovimientoDto : BaseEntity
    {
        public int IdMedicamentoFk { get; set; }
        public Medicamento Medicamento { get; set; }
        public int Cantidad { get; set; }
        public int IdMovimientoFK { get; set; }
        public Movimiento Movimiento { get; set; }
        public double PrecioUnitario { get; set; }
        public DateTime Fecha { get; set; }
    }
