using GenShop.Invoicing.App.Repositories;
using GenShop.Invoicing.Domain.Models;
using System;
using System.Collections.Generic;

namespace GenShop.Invoicing.Data.Repositories
{
    public class DummyCustomerRepository :
        BaseRepository<Customer>,
        ICustomerRepository
    {
        public DummyCustomerRepository()
            : base()
        {
            _cache = new Dictionary<Guid, Customer>
            {
                {
                    new Guid("DE989F7C-5F06-4C25-9E04-EE1412D10C74"),
                    new Customer(
                        new Guid("DE989F7C-5F06-4C25-9E04-EE1412D10C74"),
                        "Montenegrin VAT Paying Customer",
                        new Address(
                            "Cetinjski put bb",
                            "Podgorica",
                            "81000",
                            new Country(
                                "Montenegro",
                                "ME",
                                0.21,
                                false)),
                        true)
                },
                {
                    new Guid("0DB25878-1475-4F75-B763-D7EFD02F958E"),
                    new Customer(
                        new Guid("0DB25878-1475-4F75-B763-D7EFD02F958E"),
                        "Montenegrin Non VAT Paying Customer",
                        new Address(
                            "Cetinjski put bb",
                            "Podgorica",
                            "81000",
                            new Country(
                                "Montenegro",
                                "ME",
                                0.21,
                                false)),
                        false)
                },
                {
                    new Guid("69919123-9575-48C8-9E5D-21447B2958B8"),
                    new Customer(
                        new Guid("69919123-9575-48C8-9E5D-21447B2958B8"),
                        "French VAT Paying Customer",
                        new Address(
                            "Champs-Élysées",
                            "Paris",
                            "75008",
                            new Country(
                                "France",
                                "FR",
                                0.2,
                                true)),
                        true)
                },
                {
                    new Guid("EF110E71-1312-4C8B-B230-9F24789233D5"),
                    new Customer(
                        new Guid("EF110E71-1312-4C8B-B230-9F24789233D5"),
                        "French Non VAT Paying Customer",
                        new Address(
                            "Champs-Élysées",
                            "Paris",
                            "75008",
                            new Country(
                                "France",
                                "FR",
                                0.2,
                                true)),
                        false)
                },
                {
                    new Guid("33F3B296-52A5-414D-9D81-4D12F7E74771"),
                    new Customer(
                        new Guid("33F3B296-52A5-414D-9D81-4D12F7E74771"),
                        "German VAT Paying Customer",
                        new Address(
                            "Hermanstrasse 35a",
                            "Augsburg",
                            "86154",
                            new Country(
                                "Germany",
                                "DE",
                                0.19,
                                true)),
                        true)
                },
                {
                    new Guid("18902545-313C-4874-A532-E6AE4E8DB8F7"),
                    new Customer(
                        new Guid("18902545-313C-4874-A532-E6AE4E8DB8F7"),
                        "German Non VAT Paying Customer",
                        new Address(
                            "Hermanstrasse 35a",
                            "Augsburg",
                            "86154",
                            new Country(
                                "Germany",
                                "DE",
                                0.19,
                                true)),
                        false)
                }
            };
        }
    }
}
