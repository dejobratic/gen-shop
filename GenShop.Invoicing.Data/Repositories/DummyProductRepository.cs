using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace GenShop.Invoicing.Data.Repositories
{
    public class DummyProductRepository :
        BaseRepository<Product>,
        IProductRepository
    {
        public DummyProductRepository()
            : base()
        {
            _cache = new Dictionary<Guid, Product>
            {
                {
                    new Guid("82D99C3F-8870-4F9B-8807-566F4DC11E6B"),
                    new Product(
                        new Guid("82D99C3F-8870-4F9B-8807-566F4DC11E6B"),
                        "Sony Playstation 4 Pro White Version",
                        399.99,
                        new Guid("1505C663-60BA-4095-BD29-747C21794793"))
                },
                {
                    new Guid("A5A2D7A9-0134-4604-850F-34F57B1DB097"),
                    new Product(
                        new Guid("A5A2D7A9-0134-4604-850F-34F57B1DB097"),
                        "Logitech G-Series Gaming Mouse",
                        49.99,
                        new Guid("3921A583-C841-4E3E-AD90-44C7ADBFFE31"))
                },
                {
                    new Guid("648A0D50-A570-4BF2-8A8C-6E151BBA0CA8"),
                    new Product(
                        new Guid("648A0D50-A570-4BF2-8A8C-6E151BBA0CA8"),
                        "Cannon EOS 80D DSLR Camera",
                        929.99,
                        new Guid("A9E9DD15-188E-47AE-9BA7-E435DDF89470"))
                },
                {
                    new Guid("0533E620-32EB-4356-98D7-1F0A6F7010D9"),
                    new Product(
                        new Guid("0533E620-32EB-4356-98D7-1F0A6F7010D9"),
                        "Amazon Echo Dot 3rd Generation",
                        29.99,
                        new Guid("EAF51FAB-8DB8-4D73-8095-5DA37440D0F8"))
                },
                {
                    new Guid("65B6A7A0-F41C-4B09-942D-B9CEF542E6A1"),
                    new Product(
                        new Guid("65B6A7A0-F41C-4B09-942D-B9CEF542E6A1"),
                        "iPhone 11 Pro 256GB Memory",
                        599.99,
                        new Guid("C2FA76BE-0A9F-4EDA-8FE2-8C512E9874FA"))
                },
                {
                    new Guid("6BBEDDB8-CE42-4B8B-B63F-44B414F26F2B"),
                    new Product(
                        new Guid("0533E620-32EB-4356-98D7-1F0A6F7010D9"),
                        "Airpods Wireless Bluetooth Headphones",
                        89.99,
                        new Guid("B65F8070-B045-49C7-80A3-9C3C13B791B8"))
                },
            };
        }
    }
}
