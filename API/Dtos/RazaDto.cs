

using Domain.Entities;

namespace API.Dtos;
    public class RazaDto : BaseEntity
    {
         public int IdEspecieFK { get; set; }
        public Especie Especie { get; set; }
        public string Descripcion { get; set; }

        public List<MascotaDto> Mascotas { get; set; }
    }
