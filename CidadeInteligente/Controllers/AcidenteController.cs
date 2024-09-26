using AutoMapper;
using CidadeInteligente.Models;
using CidadeInteligente.Services;
using CidadeInteligente.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CidadeInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AcidenteController : ControllerBase
    {
        private readonly IAcidenteService _acidenteService;
        private readonly IMapper _mapper;

        public AcidenteController(IAcidenteService acidenteService, IMapper mapper)
        {
            _acidenteService = acidenteService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AcidenteViewModel>> GetAll()
        {
            var lista = _acidenteService.ListarAcidentes();
            var viewModelList = _mapper.Map<IEnumerable<AcidenteViewModel>>(lista);
            if (viewModelList == null)
            {
                return NoContent();
            }
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<AcidenteModel> GetById(int id)
        {
            var acidente = _acidenteService.ObterAcidentePorId(id);
            if (acidente == null)
            {
                return NotFound();
            }
            return acidente;
        }

        [HttpPost]
        public ActionResult Post([FromBody] AcidenteViewModel viewModel)
        {
            var acidente = _mapper.Map<AcidenteModel>(viewModel);
            _acidenteService.CriarAcidente(acidente);
            return CreatedAtAction(nameof(GetById), new { id = acidente.AcidenteId }, viewModel);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AcidenteViewModel viewModel)
        {
            var acidente = _acidenteService.ObterAcidentePorId(id);
            if (acidente == null)
            {
                return NotFound();
            }
            _mapper.Map(viewModel, acidente);
            _acidenteService.AtualizarAcidente(acidente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _acidenteService.DeletarAcidente(id);
            return NoContent();
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<AcidenteViewModel>> Get(int page = 1, int size = 10)
        {
            var lista = _acidenteService.ListarAcidentes(page, size);
            var viewModelList = _mapper.Map<IEnumerable<AcidenteViewModel>>(lista);
            if (viewModelList == null)
            {
                return NoContent();
            }
            return Ok(viewModelList);
        }

        [HttpGet("pagination/reference")]
        public ActionResult<IEnumerable<AcidenteViewModel>> GetByReference(int referencia = 0, int tamanho = 10)
        {
            var lista = _acidenteService.ListarAcidentesUltimaReferencia(referencia, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<AcidenteViewModel>>(lista);
            if (viewModelList == null)
            {
                return NoContent();
            }
            return Ok(viewModelList);
        }
    }
}
