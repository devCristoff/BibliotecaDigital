using AutoMapper;
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Domain.Entities;

namespace BibliotecaDigital.Core.Application.Services
{
    public class BookService : GenericService<SaveBookViewModel, BookViewModel, Book>, IBookService
    {
        private readonly IBookRepository _BookRepository;
        private readonly IMapper _mapper;

        public AutorService(IBookRepository BookRepository, IMapper mapper) : base(BookRepository, mapper)
        {
            _BookRepository = bookRepository;
            _mapper = mapper;
        }
    }
}