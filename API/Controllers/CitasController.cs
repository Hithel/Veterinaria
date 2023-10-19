
using API.Dtos;
using API.Helpers.Paginacion;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
// [Authorize]


public class CitasController :  ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public CitasController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CitasDto>>> Get()
    {
        var entidad = await unitofwork.Citas.GetAllAsync();
        return mapper.Map<List<CitasDto>>(entidad);
    }

    [HttpGet("Consulta-6/{Motivo}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Object>>> GetInfoMascotaMotivo(string Motivo)
    {
        var entidad = await unitofwork.Citas.GetInfoMascotaMotivo(Motivo);
        return mapper.Map<List<Object>>(entidad);
    }

    [HttpGet("Consulta-9/{Nombre}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Object>>> GetInfoMascotaVeterinarios(string Nombre)
    {
        var entidad = await unitofwork.Citas.GetInfoMascotaVeterinarios(Nombre);
        return mapper.Map<List<Object>>(entidad);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitasDto>> Get(int id)
    {
        var entidad = await unitofwork.Citas.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<CitasDto>(entidad);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CitasDto>>> GetPaginacion([FromQuery] Params citaParams)
    {
        var entidad = await unitofwork.Citas.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        var listEntidad = mapper.Map<List<CitasDto>>(entidad.registros);
        return new Pager<CitasDto>(listEntidad, entidad.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Citas>> Post(CitasDto entidadDto)
    {
        var entidad = this.mapper.Map<Citas>(entidadDto);
        this.unitofwork.Citas.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitasDto>> Put(int id, [FromBody]CitasDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Citas>(entidadDto);
        unitofwork.Citas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Citas.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Citas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
}
