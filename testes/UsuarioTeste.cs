using Moq;
using CidadeInteligente.Controllers;
using CidadeInteligente.Models;
using CidadeInteligente.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CidadeInteligente.Data.Repository;
using Xunit;
using CidadeInteligente.ViewModel;

namespace testes
{
    public class UsuarioTeste
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UsuarioController _usuarioController;
        private readonly  IUsuarioRepository _usuarioRepository;

        public UsuarioTeste()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _mockMapper = new Mock<IMapper>();
            _usuarioController = new UsuarioController(_mockUsuarioService.Object, _mockMapper.Object, _usuarioRepository);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfUsuarios()
        {
            // Arrange
            var usuarios = new List<UsuarioModel>
            {
                new UsuarioModel { UsuarioId = 1, UsuarioNome = "Usuario 1" },
                new UsuarioModel { UsuarioId = 2, UsuarioNome = "Usuario 2" }
            };

            _mockUsuarioService.Setup(service => service.ListarUsuarios()).Returns(usuarios);

            var usuarioViewModels = new List<UsuarioViewModel>
            {
                new UsuarioViewModel { UsuarioId = 1, UsuarioNome = "Usuario 1" },
                new UsuarioViewModel { UsuarioId = 2, UsuarioNome = "Usuario 2" }
            };

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios)).Returns(usuarioViewModels);

            // Act
            var result = _usuarioController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<UsuarioViewModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public void Post_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var usuarioViewModel = new UsuarioCreateViewModel { UsuarioNome = "Novo Usuario" };
            var usuarioModel = new UsuarioModel { UsuarioId = 1, UsuarioNome = "Novo Usuario" };

            _mockMapper.Setup(m => m.Map<UsuarioModel>(usuarioViewModel)).Returns(usuarioModel);
            _mockUsuarioService.Setup(service => service.CriarUsuario(usuarioModel)).Verifiable();

            // Act
            var result = _usuarioController.Post(usuarioViewModel);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(usuarioViewModel, createdAtActionResult.Value);
        }

        [Fact]
        public void Put_ReturnsNoContentResult()
        {
            // Arrange
            var usuarioViewModel = new UsuarioUpdateViewModel { UsuarioNome = "Usuario Atualizado" };
            var usuarioModel = new UsuarioModel { UsuarioId = 1, UsuarioNome = "Usuario Atualizado" };

            _mockUsuarioService.Setup(service => service.ObterUsuarioPorId(1)).Returns(usuarioModel);
            _mockMapper.Setup(m => m.Map(usuarioViewModel, usuarioModel)).Verifiable();
            _mockUsuarioService.Setup(service => service.AtualizarUsuario(usuarioModel)).Verifiable();

            // Act
            var result = _usuarioController.Put(1, usuarioViewModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContentResult()
        {
            // Arrange
            _mockUsuarioService.Setup(service => service.DeleterUsuario(1)).Verifiable();

            // Act
            var result = _usuarioController.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
