namespace VCard.Repositories
{
    public interface IGenericRepository<T>
    {
         Task Add(T entity);
    }
}
