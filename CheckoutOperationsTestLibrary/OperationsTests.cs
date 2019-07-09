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
        public void GivenCustomerPurchases_ReturnValidItems()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerPurchasesList = new List<char>() { 'a','b','c','d' };

            var checkoutOperator = new Operator();
            List<char> validPurchases = checkoutOperator.GetValidProducts(customerPurchasesList, productList);

            var expected = new List<char>() { 'A', 'B', 'C', 'D' };

            Assert.AreEqual(expected, validPurchases);
        }

        [Test]
        public void GivenCustomerListOfOneProduct_GetTotalCustomerPrice()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerPurchasesList = new List<char>() { 'A' };

            var checkoutOperator = new Operator();
            int customerTotal = checkoutOperator.GetCustomerTotal(productList, customerPurchasesList);

            Assert.AreEqual(50, customerTotal);
        }

        [Test]
        public void GivenCustomerListOfTwoDifferentProducts_GetTotalCustomerPriceOf80()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerPurchasesList = new List<char>(){'A','B',};

            var checkoutOperator = new Operator();
            int customerTotal = checkoutOperator.GetCustomerTotal(productList, customerPurchasesList);

            Assert.AreEqual(80, customerTotal);
        }

        [Test]
        public void GivenCustomerListOfTwoOfProductA_GetTotalCustomerPriceOf100()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerPurchasesList = new List<char>() {'A','A' };

            var checkoutOperator = new Operator();
            int customerTotal = checkoutOperator.GetCustomerTotal(productList, customerPurchasesList);

            Assert.AreEqual(100, customerTotal);
        }

        [Test]
        public void GivenCustomerPurchasesOfA_WhenCalculatingTotal_ReturnDiscountedValueOf130()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerList = new List<char>() { 'A', 'A', 'A' };

            var checkoutOperator = new Operator();
            var actualTotal = checkoutOperator.GetCustomerTotal(productList, customerList);

            Assert.AreEqual(130, actualTotal);
        }

        [Test]
        public void Given4PurchasesOfA_WhenCalculatingTotal_ReturnDiscountedValueOf180()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerList = new List<char>() { 'A', 'A', 'A', 'A',  };

            var checkoutOperator = new Operator();
            var actualTotal = checkoutOperator.GetCustomerTotal(productList, customerList);

            Assert.AreEqual(180, actualTotal);
        }

        [Test]
        public void Given6PurchasesOfA_WhenCalculatingTotal_ReturnDiscountedValueOf260()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerList = new List<char>() { 'A', 'A', 'A', 'A', 'A', 'A' };

            var checkoutOperator = new Operator();
            var actualTotal = checkoutOperator.GetCustomerTotal(productList, customerList);

            Assert.AreEqual(260, actualTotal);
        }

        [Test]
        public void Given2PurchasesOfB_WhenCalculatingTotal_ReturnDiscountedValueOf45()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerList = new List<char>() { 'B', 'B' };

            var checkoutOperator = new Operator();
            var actualTotal = checkoutOperator.GetCustomerTotal(productList, customerList);

            Assert.AreEqual(45, actualTotal);
        }

        [Test]
        public void Given3PurchasesOfB_WhenCalculatingTotal_ReturnDiscountedValueOf75()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerList = new List<char>() { 'B', 'B', 'B' };

            var checkoutOperator = new Operator();
            var actualTotal = checkoutOperator.GetCustomerTotal(productList, customerList);

            Assert.AreEqual(75, actualTotal);
        }

        [Test]
        public void Given4PurchasesOfB_WhenCalculatingTotal_ReturnDiscountedValueOf90()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerList = new List<char>() { 'B', 'B', 'B', 'B' };

            var checkoutOperator = new Operator();
            var actualTotal = checkoutOperator.GetCustomerTotal(productList, customerList);

            Assert.AreEqual(90, actualTotal);
        }

        [Test]
        public void GivenMixedListOfProduct_ReturnsDiscountedValueOf355()
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var customerList = new List<char>() { 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B','C','D' };

            var checkoutOperator = new Operator();
            var actualTotal = checkoutOperator.GetCustomerTotal(productList, customerList);

            Assert.AreEqual(335, actualTotal);
        }

    }
}
