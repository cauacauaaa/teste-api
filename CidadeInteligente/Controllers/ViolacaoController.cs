using AutoMapper;
using CidadeInteligente.Models;
using CidadeInteligente.Services;
using CidadeInteligente.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CidadeInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ViolacaoController : ControllerBase
    {
        private readonly IViolacaoService _violacaoService;
        private readonly IMapper _mapper;
        public ViolacaoController(IViolacaoService violacaoService, IMapper mapper)
        {
            _violacaoService = violacaoService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ViolacaoViewModel>> Get()
        {
            var lista = _violacaoService.ListarViolacaoes();
            var viewModelList = _mapper.Map<IEnumerable<ViolacaoViewModel>>(lista);
            if (viewModelList == null)
            {
                return NoContent();
            }
            return Ok(viewModelList);
        }
        [HttpGet("{id}")]
        public ActionResult<ViolacaoModel> Get(int id)
        {
            var violacao = _violacaoService.ObterViolacaoPorId(id);
            if (violacao == null)
            {
                return NotFound();
            }
            return violacao;
        }
        [HttpPost]
        public ActionResult Post([FromBody] ViolacaoViewModel viewModel)
        {
            var violacao = _mapper.Map<ViolacaoModel>(viewModel);
            _violacaoService.CriarViolacao(violacao);
            return CreatedAtAction(nameof(Get), new { id = violacao.ViolacaoId }, viewModel);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ViolacaoViewModel viewModel)
        {
            var violacao = _violacaoService.ObterViolacaoPorId(id);
            if (violacao == null)
            {
                return NotFound();
            }
            _mapper.Map(viewModel, violacao);
            _violacaoService.AtualizarViolacao(violacao);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _violacaoService.DeletarViolacao(id);
            return NoContent();
        }
    }
}
