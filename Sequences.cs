using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Sequences
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int CompareTwoSequences()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" };
            var wordsB = new string[] { "apple", "blueberry", "cherry" };
            //uses SequenceEqual to see if two sequences match on all elements in the same order.
            #region sequence-clause
            bool match = wordsA.SequenceEqual(wordsB);
            Console.WriteLine(match);
            #endregion
            return 0;
        }
        public int ConcatenateTwoSequences()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            //uses Concat to create one sequence that contains each array's values, one after the other.
            #region Concate-clause
            var numbersC = numbersA.Concat(numbersB);
            foreach(var num in numbersC)
            {
                Console.WriteLine(num);
            }
            #endregion
            return 0;
        }
        public int ConcatenateProjectionsFromTwoSequences()
        {
            //uses Concat to create one sequence that contains the names of all customers and products, including any duplicates.
            var customersList = GetCustomers();
            var productsList = GetProducts();
            #region Concatenate-clause
            var customersName = from customer in customersList
                                select customer.CustomerID;
            var productsName = from product in productsList
                               select product.ProductName;
            var allNames = customersName.Concat(productsName);
            foreach(var name in allNames)
            {
                Console.WriteLine(name);
            }
            #endregion
            return 0;
        }
        public int CombineSequenceWithZip()
        {
            int[] vectorA = { 0, 2, 4, 5, 6 };
            int[] vectorB = { 1, 3, 5, 7, 8 };
            //calculates the dot product of two integer vectors
            #region Zip-clause
            int dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();
            Console.WriteLine($"Dot product: {dotProduct}");
            #endregion
            return 0;
        }
    }
}
