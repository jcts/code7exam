using System;
using System.Collections.Generic;

namespace Code7.WeChip.Infra.Contracts
{
    public interface IRepositoryBase <T> : IDisposable where T : class
    {
        T GetById(Guid id);
        T Create(T entity);
        T Update(T entity);
        ICollection<T> GetAll();
    }
}
