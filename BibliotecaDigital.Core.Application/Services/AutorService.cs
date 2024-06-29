using AutoMapper;
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Domain.Entities;

namespace BibliotecaDigital.Core.Application.Services
{
    public class AutorService : GenericService<SaveAutorViewModel, AutorViewModel, Autor>, IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AutorService(IAutorRepository autorRepository, IMapper mapper) : base(autorRepository, mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }
    }
}
