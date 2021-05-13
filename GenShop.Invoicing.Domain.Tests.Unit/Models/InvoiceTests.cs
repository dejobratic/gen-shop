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
        private static readonly Order _order = OrderMockBuilder.Build();
        private static readonly Product _product = ProductMockBuilder.Build();

        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedSupplier = SupplierMockBuilder.Build();
            var expectedCustomer = CustomerMockBuilder.Build();
            var expectedAmount = new InvoiceAmount(30, 0.19);

            var actual = new Invoice(
                _order,
                _product,
                expectedSupplier,
                expectedCustomer);

            actual.Id.Should().NotBeEmpty();
            actual.Number.Should().NotBeNullOrEmpty();
            actual.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, precision: 1000);
            actual.Order.Should().Be(_order);
            actual.Product.Should().Be(_product);
            actual.Supplier.Should().Be(expectedSupplier);
            actual.Customer.Should().Be(expectedCustomer);
            actual.Amount.Should().Be(expectedAmount);
        }

        [TestMethod]
        public void Able_to_create_instance_with_persistence_constructor()
        {
            var expectedId = Guid.NewGuid();
            var expectedNumber = "Invoice#";
            var expectedCreatedAt = DateTime.UtcNow;
            var expectedSupplier = SupplierMockBuilder.Build();
            var expectedCustomer = CustomerMockBuilder.Build();
            var expectedAmount = new InvoiceAmount(30, 0.19);

            var actual = new Invoice(
                expectedId,
                expectedNumber,
                expectedCreatedAt,
                _order,
                _product,
                expectedSupplier,
                expectedCustomer,
                expectedAmount);

            actual.Id.Should().Be(expectedId);
            actual.Number.Should().Be(expectedNumber);
            actual.CreatedAt.Should().Be(expectedCreatedAt);
            actual.Order.Should().Be(_order);
            actual.Product.Should().Be(_product);
            actual.Supplier.Should().Be(expectedSupplier);
            actual.Customer.Should().Be(expectedCustomer);
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
                _order,
                _product,
                supplier,
                customer);

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
                _order,
                _product,
                supplier,
                customer);

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
                _order,
                _product,
                supplier,
                customer);

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
                _order,
                _product,
                supplier,
                customer);

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
                _order,
                _product,
                supplier,
                customer);

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
                _order,
                _product,
                supplier,
                customer);

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
