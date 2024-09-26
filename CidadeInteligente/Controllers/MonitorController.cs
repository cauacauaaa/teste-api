using AutoMapper;
using CidadeInteligente.Models;
using CidadeInteligente.Services;
using CidadeInteligente.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CidadeInteligente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MonitorController : ControllerBase
    {
        private readonly IMonitorService _monitorService;
        private readonly IMapper _mapper;
        public MonitorController(IMonitorService monitorService, IMapper mapper)
        {
            _monitorService = monitorService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MonitorViewModel>> Get()
        {
            var lista = _monitorService.ListarMonitores();
            var viewModelList = _mapper.Map<IEnumerable<MonitorViewModel>>(lista);

            return Ok(viewModelList);
        }
        [HttpGet("{id}")]
        public ActionResult<MonitorModel> Get(int id)
        {
            var monitor = _monitorService.ObterMonitorPorId(id);
            if (monitor == null)
            {
                return NotFound();
            }
            return monitor;
        }
        [HttpPost]
        public ActionResult Post([FromBody] MonitorViewModel viewModel)
        {
          
            var monitor = _mapper.Map<MonitorModel>(viewModel);
            _monitorService.CriarMonitor(monitor);
            return CreatedAtAction(nameof(Get), new { id = monitor.MonitorId }, viewModel);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MonitorViewModel viewModel)
        {
            var monitor = _monitorService.ObterMonitorPorId(id);
            if (monitor == null)
            {
                return NotFound();
            }
            _mapper.Map(viewModel, monitor);
            _monitorService.AtualizarMonitor(monitor);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _monitorService.DeletarMonitor(id);
            return NoContent();
        }
    }
}
