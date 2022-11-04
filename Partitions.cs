using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Partitions
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int[] numbers = { 1, 3, 2, 7, 12, 21, 34, 49, 59 };
        public int TakeSyntax()
        {
            //Get first 3 numbers from a numbers[]
            #region take-syntax
            //Take() syntax
            var first3Numbers = numbers.Take(3);
            //Write to console the first 3 numbers of the numbers[]
            foreach (var numb in first3Numbers)
            {
                Console.WriteLine(numb);
            }
            #endregion
            return 0;
        }
        public int NestedTake()
        {
            //Get first 3 orders from customers in Washington
            #region nestedtake-syntax
            List<Customer> customers = GetCustomers();
            //Get the first 3 customer in washington then take the first 3 out of it
            var first3WAOrders = (
                from cust in customers
                from order in cust.Orders
                where cust.Region == "WA"
                select (cust.CustomerID, order.OrderID, order.OrderDate)).Take(3);
            foreach(var cus in first3WAOrders)
            {
                Console.WriteLine(cus);
            }
            #endregion
            return 0;
        }
        public int SkipSyntax()
        {
            //Get all the value but skip first 4 elements from an array
            #region skip-syntax
            var allBut4FirstElements = numbers.Skip(4);
            foreach(var el in allBut4FirstElements)
            {
                Console.WriteLine(el);
            }
            #endregion
            return 0;
        }
    }
}
