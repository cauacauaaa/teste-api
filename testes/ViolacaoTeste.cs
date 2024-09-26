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
    public class ViolacaoTeste
    {
        private readonly Mock<IViolacaoService> _mockViolacaoService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ViolacaoController _violacaoController;

        public ViolacaoTeste()
        {
            _mockViolacaoService = new Mock<IViolacaoService>();
            _mockMapper = new Mock<IMapper>();
            _violacaoController = new ViolacaoController(_mockViolacaoService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfViolacoes()
        {
            // Arrange
            var violacoes = new List<ViolacaoModel>
            {
                new ViolacaoModel { ViolacaoId = 1, Tipo = "Violação 1" },
                new ViolacaoModel { ViolacaoId = 2, Tipo = "Violação 2" }
            };

            _mockViolacaoService.Setup(service => service.ListarViolacaoes()).Returns(violacoes);

            var violacaoViewModels = new List<ViolacaoViewModel>
            {
                new ViolacaoViewModel { ViolacaoId = 1, Tipo = "Violação 1" },
                new ViolacaoViewModel { ViolacaoId = 2, Tipo = "Violação 2" }
            };

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ViolacaoViewModel>>(violacoes)).Returns(violacaoViewModels);

            // Act
            var result = _violacaoController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<ViolacaoViewModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public void Post_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var violacaoViewModel = new ViolacaoViewModel { Tipo = "Nova Violação" };
            var violacaoModel = new ViolacaoModel { ViolacaoId = 1, Tipo = "Nova Violação" };

            _mockMapper.Setup(m => m.Map<ViolacaoModel>(violacaoViewModel)).Returns(violacaoModel);
            _mockViolacaoService.Setup(service => service.CriarViolacao(violacaoModel)).Verifiable();

            // Act
            var result = _violacaoController.Post(violacaoViewModel);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(violacaoViewModel, createdAtActionResult.Value);
        }

        [Fact]
        public void Put_ReturnsNoContentResult()
        {
            // Arrange
            var violacaoViewModel = new ViolacaoViewModel { Tipo = "Violação Atualizada" };
            var violacaoModel = new ViolacaoModel { ViolacaoId = 1, Tipo = "Violação Atualizada" };

            _mockViolacaoService.Setup(service => service.ObterViolacaoPorId(1)).Returns(violacaoModel);
            _mockMapper.Setup(m => m.Map(violacaoViewModel, violacaoModel)).Verifiable();
            _mockViolacaoService.Setup(service => service.AtualizarViolacao(violacaoModel)).Verifiable();

            // Act
            var result = _violacaoController.Put(1, violacaoViewModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContentResult()
        {
            // Arrange
            _mockViolacaoService.Setup(service => service.DeletarViolacao(1)).Verifiable();

            // Act
            var result = _violacaoController.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
