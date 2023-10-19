

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

    public class PropietarioController : ApiBaseController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;

        public PropietarioController( IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
        {
            var entidad = await unitofwork.Propietarios.GetAllAsync();
            return mapper.Map<List<PropietarioDto>>(entidad);
        }

        [HttpGet("Consulta-4")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoPropietariosMascotas()
        {
            var entidad = await unitofwork.Propietarios.GetInfoPropietariosMascotas();
            return mapper.Map<List<Object>>(entidad);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropietarioDto>> Get(int id)
        {
            var entidad = await unitofwork.Propietarios.GetByIdAsync(id);
            if (entidad == null){
                return NotFound();
            }
            return this.mapper.Map<PropietarioDto>(entidad);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PropietarioDto>>> GetPaginacion([FromQuery] Params citaParams)
        {
            var entidad = await unitofwork.Propietarios.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
            var listEntidad = mapper.Map<List<PropietarioDto>>(entidad.registros);
            return new Pager<PropietarioDto>(listEntidad, entidad.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Propietario>> Post(PropietarioDto entidadDto)
        {
            var entidad = this.mapper.Map<Propietario>(entidadDto);
            this.unitofwork.Propietarios.Add(entidad);
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
        public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody]PropietarioDto entidadDto){
            if(entidadDto == null)
            {
                return NotFound();
            }
            var entidad = this.mapper.Map<Propietario>(entidadDto);
            unitofwork.Propietarios.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            var entidad = await unitofwork.Propietarios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            unitofwork.Propietarios.Remove(entidad);
            await unitofwork.SaveAsync();
            return NoContent();
        }
    }
