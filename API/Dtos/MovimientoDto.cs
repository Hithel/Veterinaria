
using Domain.Entities;

namespace API.Dtos;
    public class MovimientoDto : BaseEntity
    {
        public int IdTipoMovimientoFK { get; set; }
        public TipoMovimiento TipoMovimientos { get; set; }
        public double PrecioTotal { get; set; }
    }
