using System.Linq;
using Domain;

namespace Data.Interface
{
    public interface IQueryableRepository<T> where T : AggregateRoot
    {
        IQueryable<T> Query();
    }
}
