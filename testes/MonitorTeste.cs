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
    public class MonitorTeste
    {
        private readonly Mock<IMonitorService> _mockMonitorService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MonitorController _monitorController;

        public MonitorTeste()
        {
            _mockMonitorService = new Mock<IMonitorService>();
            _mockMapper = new Mock<IMapper>();
            _monitorController = new MonitorController(_mockMonitorService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfMonitores()
        {
            // Arrange
            var monitores = new List<MonitorModel>
            {
                new MonitorModel { MonitorId = 1, Loc = "Monitor 1" },
                new MonitorModel { MonitorId = 2, Loc = "Monitor 2" }
            };

            _mockMonitorService.Setup(service => service.ListarMonitores()).Returns(monitores);

            var monitorViewModels = new List<MonitorViewModel>
            {
                new MonitorViewModel { MonitorId = 1, Loc = "Monitor 1" },
                new MonitorViewModel { MonitorId = 2, Loc = "Monitor 2" }
            };

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<MonitorViewModel>>(monitores)).Returns(monitorViewModels);

            // Act
            var result = _monitorController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<MonitorViewModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public void Post_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var monitorViewModel = new MonitorViewModel { MonitorId = 1, Loc = "Monitor 1" };
            var monitorModel = new MonitorModel { MonitorId = 1, Loc = "Monitor 1" };

            _mockMapper.Setup(m => m.Map<MonitorModel>(monitorViewModel)).Returns(monitorModel);
            _mockMonitorService.Setup(service => service.CriarMonitor(monitorModel)).Verifiable();

            // Act
            var result = _monitorController.Post(monitorViewModel);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(monitorViewModel, createdAtActionResult.Value);
        }

        [Fact]
        public void Put_ReturnsNoContentResult()
        {
            // Arrange
            var monitorViewModel = new MonitorViewModel { MonitorId = 1, Loc = "Monitor 1" };
            var monitorModel = new MonitorModel { MonitorId = 1, Loc = "Monitor 1" };

            _mockMonitorService.Setup(service => service.ObterMonitorPorId(1)).Returns(monitorModel);
            _mockMapper.Setup(m => m.Map(monitorViewModel, monitorModel)).Verifiable();
            _mockMonitorService.Setup(service => service.AtualizarMonitor(monitorModel)).Verifiable();

            // Act
            var result = _monitorController.Put(1, monitorViewModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContentResult()
        {
            // Arrange
            _mockMonitorService.Setup(service => service.DeletarMonitor(1)).Verifiable();

            // Act
            var result = _monitorController.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
