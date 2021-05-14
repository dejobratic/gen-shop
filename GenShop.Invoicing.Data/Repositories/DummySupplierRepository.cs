using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace GenShop.Invoicing.Data.Repositories
{
    public class DummySupplierRepository :
        BaseRepository<Supplier>,
        ISupplierRepository
    {
        public DummySupplierRepository()
            : base()
        {
            _cache = new Dictionary<Guid, Supplier>
            {
                {
                    new Guid("1505C663-60BA-4095-BD29-747C21794793"),
                    new Supplier(
                        new Guid("1505C663-60BA-4095-BD29-747C21794793"),
                        "Montenegrin VAT Paying Supplier",
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
                    new Guid("3921A583-C841-4E3E-AD90-44C7ADBFFE31"),
                    new Supplier(
                        new Guid("3921A583-C841-4E3E-AD90-44C7ADBFFE31"),
                        "Montenegrin Non VAT Paying Supplier",
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
                    new Guid("A9E9DD15-188E-47AE-9BA7-E435DDF89470"),
                    new Supplier(
                        new Guid("A9E9DD15-188E-47AE-9BA7-E435DDF89470"),
                        "French VAT Paying Supplier",
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
                    new Guid("EAF51FAB-8DB8-4D73-8095-5DA37440D0F8"),
                    new Supplier(
                        new Guid("EAF51FAB-8DB8-4D73-8095-5DA37440D0F8"),
                        "French Non VAT Paying Supplier",
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
                    new Guid("C2FA76BE-0A9F-4EDA-8FE2-8C512E9874FA"),
                    new Supplier(
                        new Guid("C2FA76BE-0A9F-4EDA-8FE2-8C512E9874FA"),
                        "German VAT Paying Supplier",
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
                    new Guid("B65F8070-B045-49C7-80A3-9C3C13B791B8"),
                    new Supplier(
                        new Guid("B65F8070-B045-49C7-80A3-9C3C13B791B8"),
                        "German Non VAT Paying Supplier",
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
