using GenShop.Invoicing.Domain.Exceptions;
using GenShop.Invoicing.Domain.Kernel;
using GenShop.Invoicing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenShop.Invoicing.Data.Repositories
{
    public abstract class BaseRepository<T> :
        IRepository<T>
        where T : Entity<Guid>
    {
        protected Dictionary<Guid, T> _cache;

        public BaseRepository()
        {
            _cache = new Dictionary<Guid, T>();
        }

        public virtual Task<T> Get(Guid id)
        {
            if (_cache.ContainsKey(id))
                return Task.FromResult(_cache[id]);

            throw new EntityNotFoundException(typeof(T));
        }

        public virtual Task Save(T entity)
        {
            if (_cache.ContainsKey(entity.Id))
                _cache[entity.Id] = entity;
            else
                _cache.Add(entity.Id, entity);

            return Task.CompletedTask;
        }
    }
}
