using BibliotecaDigital.Core.Application.ViewModels.User;
using BibliotecaDigital.Core.Domain.Entities;


namespace BibliotecaDigital.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel, User>
    {
    }
}
