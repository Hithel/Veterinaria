
namespace Domain.Entities;
    public class Raza : BaseEntity
    {
        public int IdEspecieFK { get; set; }
        public Especie Especie { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Mascota> Mascotas { get; set; }
    }
