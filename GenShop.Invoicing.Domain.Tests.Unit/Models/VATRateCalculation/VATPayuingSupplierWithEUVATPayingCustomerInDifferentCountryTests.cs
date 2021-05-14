﻿using FluentAssertions;
using GenShop.Invoicing.Domain.Models.VATRateCalculation;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models.VATRateCalculation
{
    [TestClass]
    [TestCategory("Unit")]
    public class VATPayuingSupplierWithEUVATPayingCustomerInDifferentCountryTests
    {
        private VATPayuingSupplierWithEUVATPayingCustomerInDifferentCountry _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new VATPayuingSupplierWithEUVATPayingCustomerInDifferentCountry();
        }

        [TestMethod]
        public void Returns_success_result_for_VAT_paying_supplier_with_EU_VAT_paying_customer_in_different_country()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(VATRate: 0.2),
                paysVat: true);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildFrance(),
                paysVat: true);

            var actual = _sut.Execute(supplier, customer);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(0.2);
        }

        [TestMethod]
        public void Returns_failure_result_for_non_VAT_paying_supplier_with_EU_VAT_paying_customer_in_different_country()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: false);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildFrance(),
                paysVat: false);

            var actual = _sut.Execute(supplier, customer);

            actual.IsSuccess.Should().BeFalse();
            actual.Value.Should().Be(0);
        }

        [TestMethod]
        public void Returns_failure_result_for_VAT_paying_supplier_with_non_EU_VAT_paying_customer_in_different_country()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildMontenegro(),
                paysVat: true);

            var actual = _sut.Execute(supplier, customer);

            actual.IsSuccess.Should().BeFalse();
            actual.Value.Should().Be(0);
        }

        [TestMethod]
        public void Returns_failure_result_for_VAT_paying_supplier_with_EU_non_VAT_paying_customer_in_different_country()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildFrance(),
                paysVat: false);

            var actual = _sut.Execute(supplier, customer);

            actual.IsSuccess.Should().BeFalse();
            actual.Value.Should().Be(0);
        }

        [TestMethod]
        public void Returns_failure_result_for_VAT_paying_supplier_with_EU_VAT_paying_customer_in_same_country()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var actual = _sut.Execute(supplier, customer);

            actual.IsSuccess.Should().BeFalse();
            actual.Value.Should().Be(0);
        }
    }
}
