using GenShop.Invoicing.Domain.Models;
using System;
using System.Collections.Generic;

namespace GenShop.Invoicing.Data.Repositories
{
    public class DummyOrderRepository :
        BaseRepository<Order>
    {
        public DummyOrderRepository()
            : base()
        {
            _cache = new Dictionary<Guid, Order>
            {

            };
        }
    }
}
