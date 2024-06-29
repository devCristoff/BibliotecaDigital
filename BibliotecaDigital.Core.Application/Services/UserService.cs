using AutoMapper;
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.ViewModels.User;
using BibliotecaDigital.Core.Domain.Entities;

namespace BibliotecaDigital.Core.Application.Services
{
    public class UserService : GenericService<SaveUserViewModel, UserViewModel, User>, IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository UserRepository, IMapper mapper) : base(UserRepository, mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }
    }
}
