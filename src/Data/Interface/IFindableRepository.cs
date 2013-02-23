using System;
using Domain;

namespace Data.Interface
{
    public interface IFindableRepository<T> where T : AggregateRoot
    {
        T Find(Guid id);
    }
}