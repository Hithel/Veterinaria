

namespace Domain.Entities;
    public class Especie : BaseEntity
    {
        public string Descripcion { get; set; }

        public ICollection<Raza> Razas { get; set; }
    }
