using AutoMapper;
using CidadeInteligente.Data.Repository;
using CidadeInteligente.Models;
using CidadeInteligente.Services;
using CidadeInteligente.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CidadeInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository; // Adicione a interface do repositório

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        // GET api/usuario
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioViewModel>> Get()
        {
            var lista = _usuarioService.ListarUsuarios();
            var viewModelList = _mapper.Map<IEnumerable<UsuarioViewModel>>(lista);
            if (viewModelList == null || !viewModelList.Any())
            {
                return NoContent();
            }
            return Ok(viewModelList);
        }

        // GET api/usuario/5
        [HttpGet("{id}")]
        public ActionResult<UsuarioModel> Get(int id)
        {
            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        // POST api/usuario
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioCreateViewModel viewModel)
        {
            var usuario = _mapper.Map<UsuarioModel>(viewModel);
            _usuarioService.CriarUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioId }, viewModel);
        }

        // PUT api/usuario/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioUpdateViewModel viewModel)
        {
            var usuario = _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _mapper.Map(viewModel, usuario);
            _usuarioService.AtualizarUsuario(usuario);
            return NoContent();
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _usuarioService.DeleterUsuario(id);
            return NoContent();
        }

        // GET api/usuario/paginacao
        [HttpGet("paginacao")]
        public ActionResult<IEnumerable<UsuarioModel>> GetPaginacao([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            var usuarios = _usuarioRepository.GetAll(pagina, tamanhoPagina);
            if (usuarios == null || !usuarios.Any())
            {
                return NoContent();
            }
            return Ok(usuarios);
        }

        // GET api/usuario/referencia
        [HttpGet("referencia")]
        public ActionResult<IEnumerable<UsuarioModel>> GetPorReferencia([FromQuery] int referencia = 0, [FromQuery] int tamanho = 10)
        {
            var usuarios = _usuarioRepository.GetAllReference(referencia, tamanho);
            if (usuarios == null || !usuarios.Any())
            {
                return NoContent();
            }
            return Ok(usuarios);
        }
    }
}
