using AutoMapper;
using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Application.Interfaces.Services;
using BibliotecaDigital.Core.Application.ViewModels.Autor;
using BibliotecaDigital.Core.Application.ViewModels.Book;
using BibliotecaDigital.Core.Domain.Entities;

namespace BibliotecaDigital.Core.Application.Services
{
    public class BookService : GenericService<SaveBookViewModel, BookViewModel, Book>, IBookService
    {
        private readonly IBookRepository _BookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository BookRepository, IMapper mapper) : base(BookRepository, mapper)
        {
            _BookRepository = BookRepository;
            _mapper = mapper;
        }

        public BookService(IGenericRepository<Book> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}