using FluentAssertions;
using GenShop.Invoicing.Domain.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GenShop.Invoicing.Domain.Tests.Unit.Helpers
{
    [TestClass]
    [TestCategory("Unit")]
    public class LoaderTests
    {
        public interface IExample { }
        public class FirstExample : IExample { }
        public class SecondExample : IExample { }

        [TestMethod]
        public void Able_to_load_all_interface_implementations()
        {
            var examples = Loader.LoadAllInterfaceImplementations<IExample>();

            var allTypes = examples.Select(e => e.GetType()).ToArray();

            allTypes.Should().HaveCount(2);
            allTypes.Should().Contain(typeof(FirstExample));
            allTypes.Should().Contain(typeof(SecondExample));
        }
    }
}
