using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Conversions
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int ConvertToArray()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };
            //uses ToArray to immediately evaluate a sequence into an array.
            #region Covert-clause
            var sortedDoubles = from d in doubles
                                orderby d
                                select d;
            var doubleArray = sortedDoubles.ToArray();
            foreach(var item in doubleArray)
            {
                Console.WriteLine(item);
            }
            #endregion
            return 0;
        }
        public int ConvertToList()
        {
            string[] words = { "cherry", "apple", "blueberry" };
            // uses ToList to immediately evaluate a sequence into a List<T>.
            #region Convert-clause
            var sortedWords = from w in words
                              orderby w
                              select w;
            var wordsList = sortedWords.ToList();
            foreach(var word in wordsList)
            {
                Console.WriteLine(word);
            }
            #endregion
            return 0;
        }
        public int ConvertToDictionary()
        {
            var scoreRecords = new[] { new {Name = "Alice", Score = "50" },
                                      new {Name = "John", Score = "60" },
                                      new {Name = "Holding", Score = "55" },
                                      new {Name = "Toszy", Score = "00" } };
            //uses ToDictionary to immediately evaluate a sequence and a related key expression into a dictionary.
            #region Convert-Clause
            var scoreRecordsDictionary = scoreRecords.ToDictionary(sr => sr.Name);
            foreach(var i in scoreRecords)
            {
                Console.WriteLine($"Record of {i.Name} is {i.Score}");
            }
            #endregion
            return 0;
        }
        public int ConvertBaseOnType()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };
            //uses OfType to return only the elements of the array that are of type double.
            var doubles = numbers.OfType<double>();
            #region Convert-clause
            foreach (var number in doubles)
            {
                Console.WriteLine(number);
            }
            #endregion
            return 0;
        }
    }
}
