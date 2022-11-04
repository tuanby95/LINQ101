using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    internal class Orders
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        private string[] words = { "cherry", "apple", "blueberry" };

        public int SortElement()
        {
            //Sort a string array by alphabet
            #region sort
            var sortedWords = from word in words
                              orderby word
                              select word;
            foreach(var w in sortedWords)
            {
                Console.WriteLine(w);
            }
            #endregion
            return 0;
        }
        public int SortByProperty()
        {
            //Sort a string array by length of the element
            #region sort-property
            var sortedWord = from word in words
                             orderby word.Length
                             select word;
            foreach(var w in sortedWord)
            {
                Console.WriteLine(w);
            }
            #endregion
            return 0;
        }
        public int OrderingUserDefinedTypes()
        {
            //sort a list of product by name
            var products = GetProducts();
            #region sort by defined type
            var productList = from prod in products
                              orderby prod.ProductName
                              select prod.ProductName;
            foreach(var item in productList)
            {
                Console.WriteLine(item);
            }
            #endregion
            return 0;
        }
        #region order-descending
        public int OrderByDescending()
        {
            //sort a list of doubles by descending
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };
            #region order-descending clause
            var sortedDoubles = from d in doubles
                                orderby d descending
                                select d;
            foreach(var item in sortedDoubles)
            {
                Console.WriteLine(item);
            }
            #endregion
            return 0;
        }
        public int DescendingOrderingUserDefinedTypes()
        {
            //uses orderby to sort a list of products by units in stock from highest to lowest
            var products = GetProducts();
            #region order-descending-clause
            var sortedProductList = from product in products
                                    orderby product.UnitsInStock descending
                                    select product;
            foreach(var item in sortedProductList)
            {
                Console.WriteLine(item);
            }
            #endregion
            return 0;
        }
        #endregion
        #region order then by
        public int OrderByMultipleProperties()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //uses a compound orderby to sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            #region sort-clause
            var sortedDigits = from digit in digits
                               orderby digit.Length, digit
                               select digit;
            foreach(var item in sortedDigits)
            {
                Console.WriteLine(item);
            }
            #endregion
            return 0;
        }
        public int MultipleOrderingDescending()
        {
            //uses a compound orderby to sort a list of products, first by category, and then by unit price, from highest to lowest.
            var products = GetProducts();
            #region multiple-ordering
            var sortedProductList = from product in products
                                    orderby product.Category, product.UnitPrice descending
                                    select product;
            foreach(var prod in sortedProductList)
            {
                Console.WriteLine(prod.Category + " " + prod.ProductID + " " + prod.UnitPrice);
            }
            #endregion
            return 0;
        }
        public int ReverseTheSequence()
        {
            //uses Reverse to create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            #region Reverse-clause
            var reverseDigits = (from digit in digits
                                 where digit[1] == 'i'
                                 select digit).Reverse();
            foreach(var item in reverseDigits)
            {
                Console.WriteLine(item);
            }
            #endregion
            return 0;
        }
        #endregion
        //Custom Comparer
        //public class CaseInsensitiveComparer : IComparer<string>
        //{
        //    public int Compare(string x, string y) =>
        //        string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        //}
        //public int OrderingWithCustomComparer()
        //{
        //    string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        //    var sortedWords = words.OrderBy(a => a, new CaseInsensitiveComparer());

        //    foreach (var word in sortedWords)
        //    {
        //        Console.WriteLine(word);
        //    }
        //    return 0;
        //}
    }
}
