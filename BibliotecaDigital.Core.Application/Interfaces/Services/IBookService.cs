using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Application.ViewModels.Book;
using BibliotecaDigital.Core.Domain.Entities;

namespace BibliotecaDigital.Core.Application.Interfaces.Services
{
    public interface IBookService : IGenericService<SaveBookViewModel, BookViewModel, Book>
    {

    }
}
