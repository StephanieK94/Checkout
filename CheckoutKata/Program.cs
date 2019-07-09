using CheckoutOperationsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new Dictionary<char, int>();
            productList.Add('A', 50);
            productList.Add('B', 30);
            productList.Add('C', 20);
            productList.Add('D', 15);

            var operations = new Operator();

            var customerPurchaseList = Console.ReadLine().ToList<char>();

            var validCustomerPurchases = operations.GetValidProducts(customerPurchaseList, productList);

            foreach (var purchase in validCustomerPurchases)
            {
                Console.Write(purchase + ", ");
            }

            var total = operations.GetCustomerTotal(productList, validCustomerPurchases);
            Console.WriteLine("     =   $ " + total);

        }
    }
}
