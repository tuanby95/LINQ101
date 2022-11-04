using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Generates
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int GenerateARangeOfNumber()
        {
            //uses Range to generates a sequence of integral numbers within a specified range.
            #region Range-clause
            var numbers = from n in Enumerable.Range(100, 50)
                          select (Number: n, OddEven: n % 2 == 0 ? "even" : "odd");
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
            #endregion
            return 0;
        }
        public int GenerateRepeatTheSameNumber()
        {
            // uses Repeat to generates a sequence that contains one repeated value.
            #region Repeat-clause
            var numbers = Enumerable.Repeat(7, 10);
            foreach(var num in numbers)
            {
                Console.WriteLine(num);
            }
            #endregion
            return 0;
        }
    }
}
