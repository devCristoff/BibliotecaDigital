using AutoMapper;
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.Services;
using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BibliotecaDigital.Tests.Services
{
    public class AutorServiceTests
    {
        [Fact]
        public async Task GetAll_Autores_ReturnsAllAutores()
        {
            // Arrange
            var mockRepository = new Mock<IAutorRepository>();
            var mockMapper = new Mock<IMapper>();

            // Simulamos una lista de autores
            var autores = new List<Autor>
            {
                new Autor { Id = 1, Name = "John", LastName = "Doe", Birthday = new DateTime(1980, 1, 1) },
                new Autor { Id = 2, Name = "Jane", LastName = "Smith", Birthday = new DateTime(1975, 5, 10) },
                new Autor { Id = 3, Name = "Michael", LastName = "Johnson", Birthday = new DateTime(1990, 9, 15) }
            };

            // Configuramos el repositorio falso para devolver la lista de autores
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(autores);

            var autorService = new AutorService(mockRepository.Object, mockMapper.Object);

            // Act
            var result = await autorService.GetAllViewModel();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(autores.Count, result.Count);

            for (int i = 0; i < autores.Count; i++)
            {
                Assert.Equal(autores[i].Name, result[i].Name);
                Assert.Equal(autores[i].LastName, result[i].LastName);
                Assert.Equal(autores[i].Birthday, result[i].Birthday);
            }
        }
    }
}
