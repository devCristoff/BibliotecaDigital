using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Domain.Entities;

namespace BibliotecaDigital.Core.Application.Interfaces.Services
{
    public interface IAutorService : IGenericService<SaveAutorViewModel, AutorViewModel, Autor>
    {
    }
}
