using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
        private readonly ApiContext _context;


        private CitasRepository _citas;
        private DetalleMovimientoRepository _detalleMovimientos;
        private EspecieRepository _especies;
        private LaboratorioRepository _laboratorios;
        private MascotaRepository _mascotas;
        private MedicamentoRepository _medicamentos;
        private MovimientoRepository _movimientos;
        private PropietarioRepository _propietarios;
        private ProveedorRepository _proveedores;
        private RazaRepository _razas;
        private TipoMovimientoRepository _tipoMovimientos;
        private TratamientoMedicoRepository _tratamientoMedicos;
        private VeterinarioRepository _veterinarios;

        private UserRepository _users;
        private RolRepository _roles; 

     public UnitOfWork (ApiContext context)
        {
            _context = context;
        }

        // Controll de nulos para los repositorios

         public ICitas Citas
        {
            get
            {
                if (_citas == null)
                {
                    _citas = new CitasRepository(_context);
                }
                return _citas;
            }
        }
        public IDetalleMovimiento DetalleMovimientos
        {
            get
            {
                if (_detalleMovimientos == null)
                {
                    _detalleMovimientos = new DetalleMovimientoRepository(_context);
                }
                return _detalleMovimientos;
            }
        }

        public IEspecie Especies
        {
            get
            {
                if (_especies == null)
                {
                    _especies = new EspecieRepository(_context);
                }
                return _especies;
            }
        }

        public ILaboratorio Laboratorios
        {
            get
            {
                if (_laboratorios == null)
                {
                    _laboratorios = new LaboratorioRepository(_context);
                }
                return _laboratorios;
            }
        }

        public IMascota Mascotas
        {
            get
            {
                if (_mascotas == null)
                {
                    _mascotas = new MascotaRepository(_context);
                }
                return _mascotas;
            }
        }

        public IMedicamento Medicamentos
        {
            get
            {
                if (_medicamentos == null)
                {
                    _medicamentos = new MedicamentoRepository(_context);
                }
                return _medicamentos;
            }
        }

        public IMovimiento Movimientos
        {
            get
            {
                if (_movimientos == null)
                {
                    _movimientos = new MovimientoRepository(_context);
                }
                return _movimientos;
            }
        }
        public IPropietario Propietarios
        {
            get
            {
                if (_propietarios == null)
                {
                    _propietarios = new PropietarioRepository(_context);
                }
                return _propietarios;
            }
        }
        public IProveedor Proveedores
        {
            get
            {
                if (_proveedores == null)
                {
                    _proveedores = new ProveedorRepository(_context);
                }
                return _proveedores;
            }
        }

        public IRaza Razas
        {
            get
            {
                if (_razas == null)
                {
                    _razas = new RazaRepository(_context);
                }
                return _razas;
            }
        }

        public ITipoMovimiento TipoMovimientos
        {
            get
            {
                if (_tipoMovimientos == null)
                {
                    _tipoMovimientos = new TipoMovimientoRepository(_context);
                }
                return _tipoMovimientos;
            }
        }

        public ITratamientoMedico TratamientoMedicos
        {
            get
            {
                if (_tratamientoMedicos == null)
                {
                    _tratamientoMedicos = new TratamientoMedicoRepository(_context);
                }
                return _tratamientoMedicos;
            }
        }

        public IVeterinario Veterinarios
        {
            get
            {
                if (_veterinarios == null)
                {
                    _veterinarios = new VeterinarioRepository(_context);
                }
                return _veterinarios;
            }
        }
        

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }





    }
}
