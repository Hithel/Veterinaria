

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

    public class MedicamentoController : ApiBaseController
    {
        private readonly IUnitOfWork unitofwork;
        private readonly  IMapper mapper;

        public MedicamentoController( IUnitOfWork unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
        {
            var entidad = await unitofwork.Medicamentos.GetAllAsync();
            return mapper.Map<List<MedicamentoDto>>(entidad);
        }

        [HttpGet("Consulta-2/{Laboratorio}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMedicamentoLaboratorio(string Laboratorio)
        {
            var entidad = await unitofwork.Medicamentos.GetInfoMedicamentoLaboratorio(Laboratorio);
            return mapper.Map<List<Object>>(entidad);
        }

        [HttpGet("Consulta-2/{Laboratorio}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMedicamentoLaboratorio(string Laboratorio, [FromQuery] Params Parameters)
        {
            var entidad = await unitofwork.Medicamentos.GetInfoMedicamentoLaboratorio(Laboratorio, Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }

        [HttpGet("Consulta-5/{Precio}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMedicamentoPrecio(double Precio)
        {
            var entidad = await unitofwork.Medicamentos.GetInfoMedicamentoPrecio(Precio);
            return mapper.Map<List<Object>>(entidad);
        }


        [HttpGet("Consulta-5/{Precio}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMedicamentoPrecio(double Precio,  [FromQuery] Params Parameters)
        {
            var entidad = await unitofwork.Medicamentos.GetInfoMedicamentoPrecio(Precio, Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }



        [HttpGet("Consulta-10/{Medicamento}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMedicamentoProveedor(string Medicamento)
        {
            var entidad = await unitofwork.Medicamentos.GetInfoMedicamentoProveedor(Medicamento);
            return mapper.Map<List<Object>>(entidad);
        }


        [HttpGet("Consulta-10/{Medicamento}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetInfoMedicamentoProveedor(string Medicamento, [FromQuery] Params Parameters)
        {
            var entidad = await unitofwork.Medicamentos.GetInfoMedicamentoProveedor(Medicamento, Parameters.PageIndex, Parameters.PageSize, Parameters.Search);
            var listEntidad = mapper.Map<List<Object>>(entidad.registros);
            return Ok(new Pager<Object>(listEntidad, entidad.totalRegistros, Parameters.PageIndex, Parameters.PageSize, Parameters.Search));
        }



        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicamentoDto>> Get(int id)
        {
            var entidad = await unitofwork.Medicamentos.GetByIdAsync(id);
            if (entidad == null){
                return NotFound();
            }
            return this.mapper.Map<MedicamentoDto>(entidad);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MedicamentoDto>>> GetPaginacion([FromQuery] Params citaParams)
        {
            var entidad = await unitofwork.Medicamentos.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
            var listEntidad = mapper.Map<List<MedicamentoDto>>(entidad.registros);
            return new Pager<MedicamentoDto>(listEntidad, entidad.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Medicamento>> Post(MedicamentoDto entidadDto)
        {
            var entidad = this.mapper.Map<Medicamento>(entidadDto);
            this.unitofwork.Medicamentos.Add(entidad);
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
        public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody]MedicamentoDto entidadDto){
            if(entidadDto == null)
            {
                return NotFound();
            }
            var entidad = this.mapper.Map<Medicamento>(entidadDto);
            unitofwork.Medicamentos.Update(entidad);
            await unitofwork.SaveAsync();
            return entidadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            var entidad = await unitofwork.Medicamentos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            unitofwork.Medicamentos.Remove(entidad);
            await unitofwork.SaveAsync();
            return NoContent();
        }
    }
