using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Restrictions
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int[] numbers = { 1, 4, 32, 2, 6, 87, 9, 25, 50 };

        public int QuerryStructure()
        {
            //select number < 20 from the array
            #region where-clause
            var first3Numbers = from numb in numbers
                                where numb < 20
                                select numb;
            foreach(var el in first3Numbers)
            {
                Console.WriteLine(el);
            }
            #endregion
            return 0;
        }
        public int FilterElement()
        {
            //find all of the products that are out of stock
            var productsList = GetProducts();
            #region where-clause
            var outOfStockProducts = from product in productsList
                                     where product.UnitsInStock == 0
                                     select product;
            foreach(var product in outOfStockProducts)
            {
                Console.WriteLine($"{product.ProductName} is out of stock");
            }
            #endregion
            return 0;
        }
        public int AdvancedFilter()
        {
            //find all of the product that are in stock and has price > 3.00
            var productsList = GetProducts();
            #region advanced-filter
            var filteredProductsList = from product in productsList
                                       where product.UnitsInStock > 0 && product.UnitPrice > 3.00M
                                       select product;
            foreach(var pro in filteredProductsList)
            {
                Console.WriteLine(pro.ProductName);
            }
            #endregion
            return 0;
        }
        public int SequenceProperty()
        {
            //find all customers in Washington and then uses the resulting sequence to drill down into their orders
            var customers = GetCustomers();
            #region sequence-property
            var waCustomers = from customer in customers
                                where customer.Region == "WA"
                                select customer;
            foreach(var cus in waCustomers)
            {
                Console.WriteLine($"Customer {cus.CustomerID}: {cus.CompanyName}");
                foreach(var order in cus.Orders)
                {
                    Console.WriteLine($"Order {order.OrderID}: {order.OrderDate}");
                }
            }
            #endregion
            return 0;
        }
        public int FilterBaseOnPosition()
        {
            //find an indexed Where clause that returns digits whose name is shorter than their value
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //using Where()
            var shortsList = digits.Where((digit, index) => digit.Length < index);
            return 0;
        }
    }
}
