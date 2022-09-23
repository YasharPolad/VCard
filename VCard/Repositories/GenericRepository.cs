using Microsoft.EntityFrameworkCore;
using VCard.DAL;
using VCard.Models;

namespace VCard.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly VCardDbContext _dbContext;
        public GenericRepository(VCardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            _dbContext.SaveChanges();
        }
    }
}
