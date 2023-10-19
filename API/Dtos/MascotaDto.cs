
using Domain.Entities;

namespace API.Dtos;
    public class MascotaDto : BaseEntity
    {
        public int IdPropietarioFk { get; set; }
        public Propietario Propietario { get; set; }
        public int IdRazaFK { get; set; }
        public Raza Raza{ get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimineto { get; set; }

        public List<CitasDto> Citas { get; set; }
        public List<TratamientoMedicoDto> TatamientoMedicos { get; set; }
    }
