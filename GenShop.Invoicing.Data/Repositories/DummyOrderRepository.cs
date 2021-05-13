using GenShop.Invoicing.App.Repositories;
using GenShop.Invoicing.Domain.Models;
using System;
using System.Collections.Generic;

namespace GenShop.Invoicing.Data.Repositories
{
    public class DummyOrderRepository :
        BaseRepository<Order>,
        IOrderRepository
    {
        public DummyOrderRepository()
            : base()
        {
            _cache = new Dictionary<Guid, Order>
            {
                {
                    new Guid("8FCE7D02-40C5-4DDC-B3B5-92121D6F21D3"),
                    new Order(
                        new Guid("8FCE7D02-40C5-4DDC-B3B5-92121D6F21D3"),
                        new Guid("DE989F7C-5F06-4C25-9E04-EE1412D10C74"),
                        new Guid("82D99C3F-8870-4F9B-8807-566F4DC11E6B"))
                },
                {
                    new Guid("F66379D3-7EAF-4A15-8EB8-692C0A2BF72B"),
                    new Order(
                        new Guid("F66379D3-7EAF-4A15-8EB8-692C0A2BF72B"),
                        new Guid("0DB25878-1475-4F75-B763-D7EFD02F958E"),
                        new Guid("A5A2D7A9-0134-4604-850F-34F57B1DB097"))
                },
                {
                    new Guid("40B11026-6B8C-4462-BD79-75B356C937F0"),
                    new Order(
                        new Guid("40B11026-6B8C-4462-BD79-75B356C937F0"),
                        new Guid("69919123-9575-48C8-9E5D-21447B2958B8"),
                        new Guid("648A0D50-A570-4BF2-8A8C-6E151BBA0CA8"))
                },
                {
                    new Guid("22F68A29-C81C-4C9C-9399-0FBA2588A62B"),
                    new Order(
                        new Guid("22F68A29-C81C-4C9C-9399-0FBA2588A62B"),
                        new Guid("EF110E71-1312-4C8B-B230-9F24789233D5"),
                        new Guid("0533E620-32EB-4356-98D7-1F0A6F7010D9"))
                },
                {
                    new Guid("5B405456-25D9-4503-93FF-4F2165D45F7A"),
                    new Order(
                        new Guid("5B405456-25D9-4503-93FF-4F2165D45F7A"),
                        new Guid("33F3B296-52A5-414D-9D81-4D12F7E74771"),
                        new Guid("82D99C3F-8870-4F9B-8807-566F4DC11E6B"))
                },
                {
                    new Guid("62DD2422-9C1F-4EA2-B207-A168E790BA15"),
                    new Order(
                        new Guid("62DD2422-9C1F-4EA2-B207-A168E790BA15"),
                        new Guid("18902545-313C-4874-A532-E6AE4E8DB8F7"),
                        new Guid("82D99C3F-8870-4F9B-8807-566F4DC11E6B"))
                },
            };
        }
    }
}
