using Xunit;
using Moq;
using System.Threading.Tasks;
using BibliotecaDigital.Core.Domain.Entities; 
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.Services;
using BibliotecaDigital.Core.Application.ViewModels.Book;

namespace TestProjectBook
{
    public class UnitTestAddBook
    {
        [Fact]
        public async Task AddBook_ValidBook_ReturnsSavedBook()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepository<Book>>();
            var mockService = new Mock<BookService>(mockRepository.Object);

            var newBookViewModel = new SaveBookViewModel
            {
                Title = "Nuevo libro",
                Description = "este es un nuevo libros",
                GenderId = "123",
                AutorId = 456,
                Year = 2023
            };

            // Configure the mock repository to return a book entity when AddAsync is called
            var newBook = new Book
            {
                Id = 1,
                Title = newBookViewModel.Title,
                Description = newBookViewModel.Description,
                GenderId = newBookViewModel.GenderId,
                AutorId = newBookViewModel.AutorId,
                Year = newBookViewModel.Year
            };

            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Book>())).ReturnsAsync(newBook);

            // Act
            var result = await mockService.Object.Add(newBookViewModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newBookViewModel.Title, result.Title);
            // Ensure other asserts as needed to validate the behavior
        }
    }
}
