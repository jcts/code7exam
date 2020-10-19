using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Code7.WeChip.Application.Contracts
{
    public interface IApplicationBase<T> where T : class
    {
        T GetById(Guid id);
        T Create(T model);
        T Update(T model);
        ICollection<T> GetAll();
        void Delete(T model);
    }
}
