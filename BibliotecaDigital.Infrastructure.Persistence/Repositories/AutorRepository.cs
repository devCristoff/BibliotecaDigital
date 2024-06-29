using BibliotecaDigital.Core.Application.Interfaces.Repositories;
using BibliotecaDigital.Core.Domain.Entities;
using BibliotecaDigital.Infrastructure.Persistence.Contexts;

namespace BibliotecaDigital.Infrastructure.Persistence.Repositories
{
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        private readonly ApplicationContext _dbContext;

        public AutorRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
