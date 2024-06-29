using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Domain.Entities;
using BibliotecaDigital.Infrastructure.Persistence.Contexts;

namespace BibliotecaDigital.Infrastructure.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>,IBookRepository
    {
        private readonly ApplicationContext _dbContext;

        public BookRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
