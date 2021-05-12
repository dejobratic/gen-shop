using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class InvoiceTests
    {
        private static readonly Product _product =
            new Product
            {
                Description = "Clean Code",
                Amount = 30
            };

        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedSupplier = SupplierMockBuilder.Build();
            var expectedCustomer = CustomerMockBuilder.Build();

            var actual = new Invoice(
                expectedSupplier,
                expectedCustomer,
                _product);

            actual.Number.Should().NotBeNullOrEmpty();
            actual.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, precision: 1000);
            actual.Supplier.Should().BeEquivalentTo(expectedSupplier);
            actual.Customer.Should().BeEquivalentTo(expectedCustomer);
            actual.Product.Should().BeEquivalentTo(_product);
            actual.Amount.Should().NotBeNull();
        }

        [TestMethod]
        [DynamicData(nameof(GetAllCustomers), DynamicDataSourceType.Method)]
        public void Able_to_calculate_VAT_for_non_tax_paying_eu_supplier(Customer customer)
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: false);

            var invoice = new Invoice(
                supplier,
                customer,
                _product);

            invoice.Amount.VATRate.Should().Be(0);
        }

        [TestMethod]
        [DynamicData(nameof(GetAllCustomers), DynamicDataSourceType.Method)]
        public void Able_to_calculate_VAT_for_non_tax_paying_non_eu_supplier(Customer customer)
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildMontenegro(),
                paysVat: false);

            var invoice = new Invoice(
                supplier,
                customer,
                _product);

            invoice.Amount.VATRate.Should().Be(0);
        }

        [TestMethod]
        [DynamicData(nameof(GetNonEuCustomers), DynamicDataSourceType.Method)]
        public void Able_to_calculate_VAT_for_tax_paying_eu_supplier_and_non_non_eu_customer(Customer customer)
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var invoice = new Invoice(
                supplier,
                customer,
                _product);

            invoice.Amount.VATRate.Should().Be(0);
        }

        [TestMethod]
        [DynamicData(nameof(GetNonEuCustomers), DynamicDataSourceType.Method)]
        public void Able_to_calculate_VAT_for_tax_paying_non_eu_supplier_and_non_eu_customer(Customer customer)
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildMontenegro(),
                paysVat: true);

            var invoice = new Invoice(
                supplier,
                customer,
                _product);

            invoice.Amount.VATRate.Should().Be(0);
        }

        [TestMethod]
        public void Able_to_calculate_VAT_for_tax_paying_supplier_and_non_tax_paying_eu_customer_that_do_not_live_in_same_country()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(VATRate: 0.19),
                paysVat: true);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildFrance(VATRate: 0.2),
                paysVat: false);

            var invoice = new Invoice(
                supplier,
                customer,
                _product);

            invoice.Amount.VATRate.Should().Be(0.2);
        }

        [TestMethod]
        [DynamicData(nameof(GetGermanCustomers), DynamicDataSourceType.Method)]
        public void Able_to_calculate_VAT_for_tax_paying_supplier_and_customer_that_live_in_same_country(Customer customer)
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(VATRate: 0.19),
                paysVat: true);

            var invoice = new Invoice(
                supplier,
                customer,
                _product);

            invoice.Amount.VATRate.Should().Be(0.19);
        }

        private static IEnumerable<object[]> GetAllCustomers()
        {
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildGermany(), paysVat: true) };
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildGermany(), paysVat: false) };
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildFrance(), paysVat: true) };
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildFrance(), paysVat: false) };
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildMontenegro(), paysVat: true) };
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildMontenegro(), paysVat: false) };
        }

        private static IEnumerable<object[]> GetGermanCustomers()
        {
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildGermany(), paysVat: true) };
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildGermany(), paysVat: false) };
        }

        private static IEnumerable<object[]> GetNonEuCustomers()
        {
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildMontenegro(), paysVat: true) };
            yield return new object[] { CustomerMockBuilder.Build(address: AddressMockBuilder.BuildMontenegro(), paysVat: false) };
        }
    }
}
