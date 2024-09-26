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
    public class AcidenteTeste
    {
        private readonly Mock<IAcidenteService> _mockAcidenteService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AcidenteController _acidenteController;

        public AcidenteTeste()
        {
            _mockAcidenteService = new Mock<IAcidenteService>();
            _mockMapper = new Mock<IMapper>();
            _acidenteController = new AcidenteController(_mockAcidenteService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfAcidentes()
        {
            // Arrange
            var acidentes = new List<AcidenteModel>
            {
                new AcidenteModel { AcidenteId = 1, Descricao = "Acidente 1" },
                new AcidenteModel { AcidenteId = 2, Descricao = "Acidente 2" }
            };

            _mockAcidenteService.Setup(service => service.ListarAcidentes()).Returns(acidentes);

            var acidenteViewModels = new List<AcidenteViewModel>
            {
                new AcidenteViewModel { AcidenteId = 1, Descricao = "Acidente 1" },
                new AcidenteViewModel { AcidenteId = 2, Descricao = "Acidente 2" }
            };

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<AcidenteViewModel>>(acidentes)).Returns(acidenteViewModels);

            // Act
            var result = _acidenteController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<AcidenteViewModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public void Post_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var acidenteViewModel = new AcidenteViewModel { AcidenteId = 1, Descricao = "Acidente 1" };
            var acidenteModel = new AcidenteModel { AcidenteId = 1, Descricao = "Acidente 1" };

            _mockMapper.Setup(m => m.Map<AcidenteModel>(acidenteViewModel)).Returns(acidenteModel);
            _mockAcidenteService.Setup(service => service.CriarAcidente(acidenteModel)).Verifiable();

            // Act
            var result = _acidenteController.Post(acidenteViewModel);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(acidenteViewModel, createdAtActionResult.Value);
        }

        [Fact]
        public void Put_ReturnsNoContentResult()
        {
            // Arrange
            var acidenteViewModel = new AcidenteViewModel { AcidenteId = 1, Descricao = "Acidente 1" };
            var acidenteModel = new AcidenteModel { AcidenteId = 1, Descricao = "Acidente 1" };

            _mockAcidenteService.Setup(service => service.ObterAcidentePorId(1)).Returns(acidenteModel);
            _mockMapper.Setup(m => m.Map(acidenteViewModel, acidenteModel)).Verifiable();
            _mockAcidenteService.Setup(service => service.AtulizarAcidente(acidenteModel)).Verifiable();

            // Act
            var result = _acidenteController.Put(1, acidenteViewModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContentResult()
        {
            // Arrange
            _mockAcidenteService.Setup(service => service.DeletarAcidente(1)).Verifiable();

            // Act
            var result = _acidenteController.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
