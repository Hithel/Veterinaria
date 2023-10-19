

using Domain.Entities;

namespace API.Dtos;
    public class ProveedorDto : BaseEntity
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }

        public List<MedicamentoDto> Medicamentos { get; set; }
    }
