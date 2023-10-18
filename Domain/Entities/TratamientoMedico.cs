

namespace Domain.Entities;
    public class TratamientoMedico : BaseEntity
    {
        public int IdMascotaFK { get; set; }
        public Mascota Mascota { get; set; }
        public int IdMedicamentoFk { get; set; }
        public Medicamento Medicamento { get; set; }
        public string Dosis { get; set; }
        public DateTime FechaAdministracion { get; set; }
        public string Descripcion { get; set; }
    }
