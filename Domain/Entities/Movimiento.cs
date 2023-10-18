
namespace Domain.Entities;
    public class Movimiento : BaseEntity
    {
        public int IdTipoMovimientoFK { get; set; }
        public TipoMovimiento TipoMovimientos { get; set; }
        public double PrecioTotal { get; set; }
        
    }
