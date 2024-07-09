using AutoMapper;
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.Services;
using BibliotecaDigital.Core.Application.ViewModels.Book;
using BibliotecaDigital.Core.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BibliotecaDigital.Tests.Services
{
    public class BookServiceTests
    {
        [Fact]
        public async Task Update_Book_ReturnsUpdatedBook()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepository<Book>>();
            var mockMapper = new Mock<IMapper>();

            var bookId = 1;
            var bookToUpdate = new SaveBookViewModel
            {
                Id = bookId,
                Title = "Nuevo título",
                Description = "Nueva descripción del libro",
                GenderId = "123",
                AutorId = 456,
                Year = 2023
            };

            var updatedBook = new Book
            {
                Id = bookId,
                Title = bookToUpdate.Title,
                Description = bookToUpdate.Description,
                GenderId = bookToUpdate.GenderId,
                AutorId = bookToUpdate.AutorId,
                Year = bookToUpdate.Year
            };

            mockRepository.Setup(repo => repo.GetByIdAsync(bookId)).ReturnsAsync(updatedBook);
            mockMapper.Setup(mapper => mapper.Map(bookToUpdate, updatedBook)).Returns(updatedBook);
            mockRepository.Setup(repo => repo.UpdateAsync(updatedBook, bookId)).Returns(Task.CompletedTask);

            var bookService = new BookService(mockRepository.Object, mockMapper.Object);

            // Act
            await bookService.Update(bookToUpdate, bookId);

            // Assert
            // Verificamos que se llamó a GetByIdAsync y UpdateAsync exactamente una vez cada uno con los parámetros esperados
            mockRepository.Verify(repo => repo.GetByIdAsync(bookId), Times.Once);
            mockRepository.Verify(repo => repo.UpdateAsync(updatedBook, bookId), Times.Once);
        }
    }
}
