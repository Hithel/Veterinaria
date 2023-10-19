

using Domain.Entities;

namespace API.Dtos;
    public class TipoMovimentoDto : BaseEntity
    {
        public string Descripcion { get; set; }
        public List<MovimientoDto> Movimientos { get; set; }
    }
