using System;
using NUnit.Framework;
using CheckoutOperationsLibrary;
using System.Collections.Generic;

namespace CheckoutOperationsTestLibrary
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void GivenProduct_ReturnDictionaryOfOne()
        {
            var product = 'A';
            var price = 50;

            var checkoutOperator = new Operator();
            var productList = checkoutOperator.GetProductDictionary(product, price);

            Assert.AreEqual(1, productList.Count);
        }

        [Test]
        public void GivenProductListOfOne_GetTotalPrice()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);

            var checkoutOperator = new Operator();
            int totalPrice = checkoutOperator.GetCustomerTotal(productList);

            Assert.AreEqual(50, totalPrice);
        }
    }
}
