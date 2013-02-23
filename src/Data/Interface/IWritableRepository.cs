using Domain;

namespace Data.Interface
{
    public interface IWritableRepository<T> where T : AggregateRoot
    {
        void Save(T entity);

        void Delete(T entity);
    }
}
