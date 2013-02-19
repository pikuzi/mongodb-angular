﻿using System;
using Web.Domain;

namespace Web.Data.Interface
{
    public interface IFindableRepository<T> where T : AggregateRoot
    {
        T Find(Guid id);
    }
}