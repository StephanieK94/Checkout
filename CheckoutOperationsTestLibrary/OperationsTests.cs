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
            var productList = checkoutOperator.AddToProductDictionary(product, price);

            Assert.AreEqual(1, productList.Count);
        }


        [Test]
        public void GivenCustomerListOfOneProduct_GetTotalCustomerPrice()
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

        [Test]
        public void GivenCustomerListOfTwoDifferentProducts_GetTotalCustomerPriceOf50()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerPurchasesList = new List<char>()
            {
                'A',
                'B',
            };

            var checkoutOperator = new Operator();
            int customerTotal = checkoutOperator.GetCustomerTotal(productList, customerPurchasesList);

            Assert.AreEqual(80, customerTotal);
        }

        [Test]
        public void GivenCustomerListOfTwoOfSameProducts_GetTotalCustomerPriceOf100()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerPurchasesList = new List<char>()
            {
                'A',
                'A',
            };

            var checkoutOperator = new Operator();
            int customerTotal = checkoutOperator.GetCustomerTotal(productList, customerPurchasesList);

            Assert.AreEqual(100, customerTotal);
        }

        [Test]
        public void GivenCountOf1ForProductA_ReturnsFalseToDiscountValidity()
        {
            var countOfProduct = 1;
            var product = 'A';

            var checkoutOperator = new Operator();
            bool discountIsValid = checkoutOperator.IsValidForDiscount(countOfProduct);

            Assert.False(discountIsValid);
        }

        [Test]
        public void GivenCountOf3ForProductA_ReturnsTrueToDiscountValidity()
        {
            var countOfProductA = 3;

            var checkoutOperator = new Operator();
            bool discountIsValid = checkoutOperator.IsValidForDiscount(countOfProductA);

            Assert.True(discountIsValid);
        }
    }
}
