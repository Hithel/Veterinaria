

using Domain.Entities;

namespace API.Dtos;
    public class EspecieDto : BaseEntity
    {
        public string Descripcion { get; set; }

        public List<RazaDto> Razas { get; set; }
    }
