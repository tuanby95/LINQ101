using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Sets
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int FindDistinctElement()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };
            // uses Distinct to remove duplicate elements in a sequence of factors of 300.
            #region Distinct-clause
            var uniqueFactors = factorsOf300.Distinct();
            Console.WriteLine("Prime factor of 300:");
            foreach(var factor in uniqueFactors)
            {
                Console.WriteLine(factor);
            }
            #endregion
            return 0;
        }
        public int FindDistinctValue()
        {
            //uses Distinct to find the unique Category names.
            var productsList = GetProducts();
            #region distinct-clause
            var categoryNames = (from product in productsList
                                select product.Category).Distinct();
            foreach(var category in categoryNames)
            {
                Console.WriteLine(category);
            }
            #endregion
            return 0;
        }
        public int FindTheUnionOfSets()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            //uses Union to create one sequence that contains the unique values from both arrays.
            #region Union-clause
            var unionNumbers = numbersA.Union(numbersB);
            foreach(var number in unionNumbers)
            {
                Console.WriteLine(number);
            }
            #endregion
            return 0;
        }
        public int UnionOfQueryResult()
        {
            //uses Union to create one sequence that contains the unique first letter from both product and customer names.
            //It shows how you can combine the results of two different queries that produce the same element type.
            var customersList = GetCustomers();
            var productsList = GetProducts();
            #region union-result
            var productFirstLetter = from product in productsList
                                     select product.ProductName[0];
            var customerFirstLetter = from customer in customersList
                                      select customer.CompanyName[0];
            var uniqueFirstChars = productFirstLetter.Union(customerFirstLetter);
            Console.WriteLine("Unique first letters from Product names and Customer names:");
            foreach (var uniqueChar in uniqueFirstChars)
            {
                Console.WriteLine(uniqueChar);
            }
            #endregion
            return 0;
        }
        public int FindTheIntersection()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            // uses Intersect to create one sequence that contains the common values shared by both arrays.
            #region Intersection-clause
            var commonValues = numbersA.Intersect(numbersB);
            foreach(var val in commonValues)
            {
                Console.WriteLine(val);
            }
            #endregion
            return 0;
        }
        public int FindTheIntersectionOfQueryResult()
        {
            //uses Intersect to create one sequence that contains the common first letter from both product and customer names.
            var customersList = GetCustomers();
            var productsList = GetProducts();
            #region Interset-clause
            var customerFirstLetter = from customer in customersList
                                      select customer.CompanyName[0];
            var productFirstLetter = from product in productsList
                                     select product.ProductName[0];
            var commonFirstLetter = customerFirstLetter.Intersect(productFirstLetter);
            foreach(var letter in commonFirstLetter)
            {
                Console.WriteLine(letter);
            }
            #endregion
            return 0;
        }
        public int FindDifference()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            //uses Except to create a sequence that contains the values from numbersA that are not also in numbersB
            #region Except-clause
            var differenceNumbers = numbersA.Except(numbersB);
            foreach(var num in differenceNumbers)
            {
                Console.WriteLine(num);
            }
            #endregion
            return 0;
        }
        public int FindDifferenceOfQueries()
        {
            //uses Except to create one sequence that contains the first letters of product names that are not also first letters of customer names
            var customersList = GetCustomers();
            var productsList = GetProducts();
            #region Excecpt-clause
            var productNameFirstChars = from product in productsList
                                        select product.ProductName[0];
            var customerNameFirstChars = from customer in customersList
                                         select customer.CompanyName[0];
            var productOnlyFirstChars = productNameFirstChars.Except(customerNameFirstChars);
            foreach(var prodChar in productOnlyFirstChars)
            {
                Console.WriteLine(prodChar);
            }
            #endregion
            return 0;
        }
    }
}
