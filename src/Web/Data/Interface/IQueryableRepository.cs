using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain;

namespace Web.Data.Interface
{
    public interface IQueryableRepository<T> where T : AggregateRoot
    {
        IQueryable<T> Query();
    }
}
