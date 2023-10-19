

namespace Domain.Interfaces;
    public interface  IUnitOfWork
    {
        ICitas Citas { get; }
        IDetalleMovimiento DetalleMovimientos { get; }
        IEspecie Especies { get; }
        ILaboratorio Laboratorios { get; }
        IMascota Mascotas { get; }
        IMedicamento Medicamentos { get; }
        IMovimiento Movimientos { get; }
        IPropietario Propietarios { get; }
        IProveedor Proveedores { get; }
        IRaza Razas { get; }
        ITipoMovimiento TipoMovimientos { get; }
        ITratamientoMedico TratamientoMedicos { get; }
        IVeterinario Veterinarios { get; }
        IRol Roles { get; }
        IUser Users { get; }
        Task<int> SaveAsync();
    }
