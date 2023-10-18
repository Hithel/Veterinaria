

namespace Domain.Entities;
    public class Mascota : BaseEntity
    {
        public int IdPropietarioFk { get; set; }
        public Propietario Propietario { get; set; }
        public int IdRazaFK { get; set; }
        public Raza Raza{ get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimineto { get; set; }

        public ICollection<Citas> Citas { get; set; }
        public ICollection<TratamientoMedico> TatamientoMedicos { get; set; } 
    }
