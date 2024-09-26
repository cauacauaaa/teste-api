using Moq;
using CidadeInteligente.Controllers;
using CidadeInteligente.Models;
using CidadeInteligente.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CidadeInteligente.ViewModel;

namespace testes
{
    public class SemaforoTeste
    {
        private readonly Mock<ISemaforoService> _mockSemaforoService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly SemaforoController _semaforoController;

        public SemaforoTeste()
        {
            _mockSemaforoService = new Mock<ISemaforoService>();
            _mockMapper = new Mock<IMapper>();
            _semaforoController = new SemaforoController(_mockSemaforoService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfSemaforos()
        {
            // Arrange
            var semaforos = new List<SemaforoModel>
            {
                new SemaforoModel { SemaforoId = 1, Estado = "Semaforo 1" },
                new SemaforoModel { SemaforoId = 2, Estado = "Semaforo 2" }
            };

            _mockSemaforoService.Setup(service => service.ListarSemaforos()).Returns(semaforos);

            var semaforoViewModels = new List<SemaforoViewModel>
            {
                new SemaforoViewModel { SemaforoId = 1, Estado = "Semaforo 1" },
                new SemaforoViewModel { SemaforoId = 2, Estado = "Semaforo 2" }
            };

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<SemaforoViewModel>>(semaforos)).Returns(semaforoViewModels);

            // Act
            var result = _semaforoController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<SemaforoViewModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public void Post_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var semaforoViewModel = new SemaforoViewModel { SemaforoId = 1, Estado = "Semaforo 1" };
            var semaforoModel = new SemaforoModel { SemaforoId = 1, Estado = "Semaforo 1" };

            _mockMapper.Setup(m => m.Map<SemaforoModel>(semaforoViewModel)).Returns(semaforoModel);
            _mockSemaforoService.Setup(service => service.CriarSemaforo(semaforoModel)).Verifiable();

            // Act
            var result = _semaforoController.Post(semaforoViewModel);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(semaforoViewModel, createdAtActionResult.Value);
        }

        [Fact]
        public void Put_ReturnsNoContentResult()
        {
            // Arrange
            var semaforoViewModel = new SemaforoViewModel { SemaforoId = 1, Estado = "Semaforo 1" };
            var semaforoModel = new SemaforoModel { SemaforoId = 1, Estado = "Semaforo 1" };

            _mockSemaforoService.Setup(service => service.ObterSemaforoPorId(1)).Returns(semaforoModel);
            _mockMapper.Setup(m => m.Map(semaforoViewModel, semaforoModel)).Verifiable();
            _mockSemaforoService.Setup(service => service.AtualizarSemaforo(semaforoModel)).Verifiable();

            // Act
            var result = _semaforoController.Put(1, semaforoViewModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContentResult()
        {
            // Arrange
            _mockSemaforoService.Setup(service => service.DeletarSemaforo(1)).Verifiable();

            // Act
            var result = _semaforoController.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
