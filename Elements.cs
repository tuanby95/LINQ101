using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Elements
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int FindTheFirstElement()
        {
            //uses First to return the first matching element as a Product, instead of as a sequence containing a Product.
            var productsList = GetProducts();
            var firstProduct = productsList.First();
            Console.WriteLine(firstProduct);
            return 0;
        }
        public int FindTheFirstMatchingList()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //uses First to find the first element in the array that starts with 'o'.
            #region First method
            string startWithO = strings.First(s => s[0] == 'o');
            Console.WriteLine(startWithO);
            #endregion
            return 0;
        }
        public int FindElementOfEmptySequence()
        {
            int[] numbers = { };
            //uses FirstOrDefault to try to return the first element of the sequence,
            //unless there are no elements, in which case the default value for that type is returned.
            int firstNumberOrDefault = numbers.FirstOrDefault();
            Console.WriteLine(firstNumberOrDefault);
            return 0;
        }
        public int FindFirstMatchingElementOrDefault()
        {
            //uses FirstOrDefault to return the first product whose ProductID is 789 as a single Product object,
            //unless there is no match, in which case null is returned.
            var productsList = GetProducts();
            #region FirstOrDefault method
            var product789 = productsList.FirstOrDefault(p => p.ProductID == 789);
            Console.WriteLine($"Product 789 exists: {product789 != null}");
            #endregion
            return 0;
        }
        public int FindElementAtPosition()
        {
            //uses ElementAt to retrieve the second number greater than 5 from an array
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var greaterThanFive = (from num in numbers
                                   where num > 5
                                   select num).ElementAt(1);
            Console.WriteLine(greaterThanFive);
            return 0;
        }

    }
}
