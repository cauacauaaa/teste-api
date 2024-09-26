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
    public class SemaforoController : ControllerBase
    {
        private readonly ISemaforoService _semaforoService;
        private readonly IMapper _mapper;
        public SemaforoController(ISemaforoService semaforoService, IMapper mapper)
        {
            _semaforoService = semaforoService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SemaforoViewModel>> Get()
        {
            var lista = _semaforoService.ListarSemaforos();
            var viewModelList = _mapper.Map<IEnumerable<SemaforoViewModel>>(lista);
            if (viewModelList == null)
            {
                return NoContent();
            }
            return Ok(viewModelList);
        }
        [HttpGet("{id}")]
        public ActionResult<SemaforoModel> Get(int id)
        {
            var semaforo = _semaforoService.ObterSemaforoPorId(id);
            if (semaforo == null)
            {
                return NotFound();
            }
            return semaforo;
        }
        [HttpPost]
        public ActionResult Post([FromBody] SemaforoViewModel viewModel)
        {
            var semaforo = _mapper.Map<SemaforoModel>(viewModel);
            _semaforoService.CriarSemaforo(semaforo);
            return CreatedAtAction(nameof(Get), new { id = semaforo.SemaforoId }, viewModel);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SemaforoViewModel viewModel)
        {
            var semaforo= _semaforoService.ObterSemaforoPorId(id);
            if (semaforo == null)
            {
                return NotFound();
            }
            _mapper.Map(viewModel, semaforo);
            _semaforoService.AtualizarSemaforo(semaforo);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _semaforoService.DeletarSemaforo(id);
            return NoContent();
        }
    }
}
