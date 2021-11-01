﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;

namespace Rent.Server.Repositories
{
    public interface IAppRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<AppDataResult<T>> GetByTitle(string title, int skip = 0, int take = 5, string orderBy = "Title");
        Task<IEnumerable<T>> GetAllExpr(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> Edit(T entity);
    }
}