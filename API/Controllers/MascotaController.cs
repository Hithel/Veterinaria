

using API.Dtos;
using API.Helpers.Paginacion;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
// [Authorize]

    public class MascotaController : ApiBaseController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;

        public MascotaController( IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
        {
            var entidad = await unitofwork.Mascotas.GetAllAsync();
            return mapper.Map<List<MascotaDto>>(entidad);
        }

        [HttpGet("Consulta-3/{Especie}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMascotaEspecie(string Especie)
        {
            var entidad = await unitofwork.Mascotas.GetInfoMascotaEspecie(Especie);
            return mapper.Map<List<Object>>(entidad);
        }

        [HttpGet("Consulta-3/{Especie}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMascotaEspecie(string Especie,[FromQuery] Params Parameters)
        {
            var entidad = await unitofwork.Mascotas.GetInfoMascotaEspecie(Especie, Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }

        [HttpGet("Consulta-7")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetAgruparMascotaEspecie()
        {
            var entidad = await unitofwork.Mascotas.GetAgruparMascotaEspecie();
            return mapper.Map<List<Object>>(entidad);
        }


        [HttpGet("Consulta-7")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetAgruparMascotaEspecie([FromQuery] Params Parameters)
        {
            var entidad = await unitofwork.Mascotas.GetAgruparMascotaEspecie(Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }




        [HttpGet("Consulta-11/{Raza}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetMascotasYPropietariosporRaza(string Raza)
        {
            var entidad = await unitofwork.Mascotas.GetMascotasYPropietariosporRaza(Raza);
            return mapper.Map<List<Object>>(entidad);
        }


        [HttpGet("Consulta-11/{Raza}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetMascotasYPropietariosporRaza(string Raza, [FromQuery] Params Parameters)
        {
            var entidad = await unitofwork.Mascotas.GetMascotasYPropietariosporRaza(Raza,Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }

        [HttpGet("Consulta-12")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetCantidadMascotasRaza()
        {
            var entidad = await unitofwork.Mascotas.GetCantidadMascotasRaza();
            return mapper.Map<List<Object>>(entidad);
        }

        [HttpGet("Consulta-12")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetCantidadMascotasRaza([FromQuery] Params Parameters)
        {
            var entidad = await unitofwork.Mascotas.GetCantidadMascotasRaza(Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaDto>> Get(int id)
        {
            var entidad = await unitofwork.Mascotas.GetByIdAsync(id);
            if (entidad == null){
                return NotFound();
            }
            return this.mapper.Map<MascotaDto>(entidad);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MascotaDto>>> GetPaginacion([FromQuery] Params citaParams)
        {
            var entidad = await unitofwork.Mascotas.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
            var listEntidad = mapper.Map<List<MascotaDto>>(entidad.registros);
            return new Pager<MascotaDto>(listEntidad, entidad.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Mascota>> Post(MascotaDto entidadDto)
        {
            var entidad = this.mapper.Map<Mascota>(entidadDto);
            this.unitofwork.Mascotas.Add(entidad);
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
        public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody]MascotaDto entidadDto){
            if(entidadDto == null)
            {
                return NotFound();
            }
            var entidad = this.mapper.Map<Mascota>(entidadDto);
            unitofwork.Mascotas.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            var entidad = await unitofwork.Mascotas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            unitofwork.Mascotas.Remove(entidad);
            await unitofwork.SaveAsync();
            return NoContent();
        }
    }
