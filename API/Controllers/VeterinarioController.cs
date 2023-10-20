

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

    public class VeterinarioController : ApiBaseController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;

        public VeterinarioController( IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
        {
            var entidad = await unitofwork.Veterinarios.GetAllAsync();
            return mapper.Map<List<VeterinarioDto>>(entidad);
        }

        [HttpGet("Consulta-1/{Especialidad}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<Object>> GetEspecialidad(string Especialidad)
        {
            var entidad = await unitofwork.Veterinarios.GetEspecialidad(Especialidad);
            return mapper.Map<List<Object>>(entidad);
        }

        [HttpGet("Consulta-1/{Especialidad}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetEspecialidad(string Especialidad, [FromQuery] Params Parameters)
        {

            var entidad = await unitofwork.Veterinarios.GetEspecialidad(Especialidad, Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VeterinarioDto>>> GetPaginacion([FromQuery] Params citaParams)
        {
            var entidad = await unitofwork.Veterinarios.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
            var listEntidad = mapper.Map<List<VeterinarioDto>>(entidad.registros);
            return new Pager<VeterinarioDto>(listEntidad, entidad.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VeterinarioDto>> Get(int id)
        {
            var entidad = await unitofwork.Veterinarios.GetByIdAsync(id);
            if (entidad == null){
                return NotFound();
            }
            return this.mapper.Map<VeterinarioDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Veterinario>> Post(VeterinarioDto entidadDto)
        {
            var entidad = this.mapper.Map<Veterinario>(entidadDto);
            this.unitofwork.Veterinarios.Add(entidad);
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
        public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody]VeterinarioDto entidadDto){
            if(entidadDto == null)
            {
                return NotFound();
            }
            var entidad = this.mapper.Map<Veterinario>(entidadDto);
            unitofwork.Veterinarios.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            var entidad = await unitofwork.Veterinarios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            unitofwork.Veterinarios.Remove(entidad);
            await unitofwork.SaveAsync();
            return NoContent();
        }


    }
