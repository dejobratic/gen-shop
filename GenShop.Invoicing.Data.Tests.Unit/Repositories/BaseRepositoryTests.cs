using FluentAssertions;
using GenShop.Invoicing.Data.Repositories;
using GenShop.Invoicing.Domain.Exceptions;
using GenShop.Invoicing.Domain.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace GenShop.Invoicing.Data.Tests.Unit.Repositories
{
    [TestCategory("Unit")]
    public abstract class BaseRepositoryTests<T>
        where T : Entity<Guid>
    {
        protected BaseRepository<T> _sut;

        [TestInitialize]
        public virtual void Initialize()
        {
            CreateSut();
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public void Throws_exception_when_trying_to_get_nonexistent_entity()
        {
            Func<Task> action = ()
                => _sut.Get(Guid.NewGuid());

            action.Should().Throw<EntityNotFoundException>()
                .WithMessage($"{typeof(T).Name} not found.");
        }

        public abstract Task Able_to_get_existing_entity();

        public abstract Task Able_to_update_existing_entity();

        protected abstract void CreateSut();
    }
}
