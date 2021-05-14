using GenShop.Invoicing.Domain.Kernel;
using System;
using System.Threading.Tasks;

namespace GenShop.Invoicing.Domain.Repositories
{
    public interface IRepository<T>
        where T : Entity<Guid>
    {
        Task<T> Get(Guid id);
        Task Save(T entity);
    }
}
