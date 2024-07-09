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
using Assert = Xunit.Assert; // Alias para Xunit.Assert

namespace BibliotecaDigital.Tests.Services
{
    public class AutorServiceTests
    {
        [Fact]
        public async Task Add_Autor_Success()
        {
            // Arrange
            var mockRepository = new Mock<IAutorRepository>();
            var mockMapper = new Mock<IMapper>();

            var newAutorViewModel = new SaveAutorViewModel
            {
                Name = "John",
                LastName = "Doe",
                Birthday = new DateTime(1980, 1, 1)
            };

            var newAutor = new Autor
            {
                Id = 1,
                Name = newAutorViewModel.Name,
                LastName = newAutorViewModel.LastName,
                Birthday = newAutorViewModel.Birthday
            };

            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Autor>())).ReturnsAsync(newAutor);
            var autorService = new AutorService(mockRepository.Object, mockMapper.Object);

            // Act
            var result = await autorService.Add(newAutorViewModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newAutorViewModel.Name, result.Name);
            Assert.Equal(newAutorViewModel.LastName, result.LastName);
            Assert.Equal(newAutorViewModel.Birthday, result.Birthday);
        }
    }
}
