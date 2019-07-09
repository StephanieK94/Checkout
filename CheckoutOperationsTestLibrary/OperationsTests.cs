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

        //[Test]
        //public void GivenFullProductDictionary_GetTotalCostOfPriceList()
        //{
        //    var productList = new Dictionary<char, int>();
        //    productList.Add('A', 50);
        //    productList.Add('B', 30);
        //    productList.Add('C', 20);
        //    productList.Add('D', 15);

        //    var checkoutOperator = new Operator();
        //    int totalPrice = checkoutOperator.GetCustomerTotal(productList);

        //    Assert.AreEqual(115, totalPrice);
        //}

        [Test]
        public void GivenCustomerListOfOneProdcut_GetTotalCustomerPrice()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerPurchasesList = new List<char>()
            {
                'A',
            };

            var checkoutOperator = new Operator();
            int customerTotal = checkoutOperator.GetCustomerTotal(productList, customerPurchasesList);

            Assert.AreEqual(50, customerTotal);
        }
    }
}
