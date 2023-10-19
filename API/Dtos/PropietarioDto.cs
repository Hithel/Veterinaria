

using Domain.Entities;

namespace API.Dtos;
    public class PropietarioDto : BaseEntity
    {
         public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }

        public List<MascotaDto> Mascota { get; set;}
    }
