
namespace Domain.Entities;
    public class Citas : BaseEntity
    {
        public int IdMascotaFk { get; set; }
        public Mascota Mascota { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set;}
        public int IdVeterinarioFK { get; set; }
        public Veterinario Veterinario{ get; set; }
        public int IdUserFK { get; set; }
        public User User { get; set; }
    }