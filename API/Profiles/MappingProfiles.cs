

using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Citas,CitasDto>().ReverseMap();
        CreateMap<DetalleMovimiento,DetalleMovimientoDto>().ReverseMap();
        CreateMap<Especie,EspecieDto>().ReverseMap();
        CreateMap<Laboratorio,LaboratorioDto>().ReverseMap();
        CreateMap<Mascota,MascotaDto>().ReverseMap();
        CreateMap<Medicamento,MedicamentoDto>().ReverseMap();
        CreateMap<Movimiento,MovimientoDto>().ReverseMap();
        CreateMap<Propietario,PropietarioDto>().ReverseMap();
        CreateMap<Proveedor,ProveedorDto>().ReverseMap();
        CreateMap<Raza,RazaDto>().ReverseMap();
        CreateMap<TipoMovimiento,TipoMovimentoDto>().ReverseMap();
        CreateMap<TratamientoMedico,TratamientoMedicoDto>().ReverseMap();
        CreateMap<Veterinario,VeterinarioDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<Rol,RolDto>().ReverseMap();
        

    }
}