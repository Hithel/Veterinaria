

using Domain.Entities;

namespace API.Dtos;
    public class VeterinarioDto : BaseEntity
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Especialidad { get; set; }

        public List<CitasDto> Citas { get; set; }
    }
