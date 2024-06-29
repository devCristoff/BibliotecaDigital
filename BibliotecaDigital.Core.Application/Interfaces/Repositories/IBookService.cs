using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Domain.Entities;

namespace BibliotecaDigital.Core.Application.Interfaces.Repositories
{
    public interface IBookService : IGenericService<SaveBookViewModel, BookViewModel, IBookService>
    {
    }
}