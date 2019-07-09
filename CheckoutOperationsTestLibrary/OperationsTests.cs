using System;
using NUnit.Framework;
using CheckoutOperationsLibrary;

namespace CheckoutOperationsTestLibrary
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void GivenProduct_ReturnPriceOf50()
        {
            var product = 'A';

            var checkoutOperator = new Operator();
            var price = checkoutOperator.GetPrice(product);

            Assert.AreEqual(50, price);
        }
    }
}
