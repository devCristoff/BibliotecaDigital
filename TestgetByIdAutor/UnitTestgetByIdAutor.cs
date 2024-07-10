using AutoMapper;
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.Services;
using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Domain.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BibliotecaDigital.Tests.Services
{
    public class AutorServiceTests
    {
        [Fact]
        public async Task GetById_Autor_ReturnsAutorById()
        {
            // Arrange
            var mockRepository = new Mock<IAutorRepository>();
            var mockMapper = new Mock<IMapper>();

            var autorId = 1;
            var autor = new Autor { Id = autorId, Name = "John", LastName = "Doe", Birthday = new DateTime(1980, 1, 1) };

            // Configuramos el repositorio falso para devolver el autor por su Id
            mockRepository.Setup(repo => repo.GetByIdAsync(autorId)).ReturnsAsync(autor);

            var autorService = new AutorService(mockRepository.Object, mockMapper.Object);

            // Act
            var result = await autorService.GetByIdSaveViewModel(autorId);

            // xunit
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(autor.Id, result.Id);
            Xunit.Assert.Equal(autor.Name, result.Name);
            Xunit.Assert.Equal(autor.LastName, result.LastName);
            Xunit.Assert.Equal(autor.Birthday, result.Birthday);
        }
    }
}
