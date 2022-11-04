using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Aggregators
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        #region Count
        public int CountAllElements()
        {
            //uses Count to get the number of unique factors of 300.
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };
            #region Count clause
            int uniqueFactor = factorsOf300.Distinct().Count();
            Console.WriteLine(uniqueFactor);
            #endregion
            return 0;
        }
        public int CountAllMatchingElements()
        {
            //uses Count to get the number of odd ints in the array.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Count clause
            var oddNumbers = numbers.Count(p => p % 2 == 1);
            Console.WriteLine("There are {0} odd numbers in numbers", oddNumbers);
            #endregion
            return 0;
        }
        public int CountAllElementsInNested()
        {
            //uses Count to return a list of customers and how many orders each has.
            var customersList = GetCustomers();
            var ordersCount = from customer in customersList
                              select (CustomerID: customer.CustomerID, OrdersCount: customer.Orders.Count());
            foreach(var order in ordersCount)
            {
                Console.WriteLine($"Id: {order.CustomerID}, Amount of order: {order.OrdersCount}");
            }
            return 0;
        }
        public int CountElementsInGroup()
        {
            //uses Count to return a list of categories and how many products each has.
            var productsList = GetProducts();
            var categoriesList = from product in productsList
                                 group product by product.Category into g
                                 select (Category: g.Key, Amount: g.Count());
            foreach(var category in categoriesList)
            {
                Console.WriteLine($"The amount of product in {category.Category} category is {category.Amount}");
            }
            return 0;
        }
        #endregion
        #region Sum
        public int SumNumbericElements()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //uses Sum to get the total of the numbers in an array.
            #region Sum-clause
            double numSum = numbers.Sum();
            Console.WriteLine(numSum);
            #endregion
            return 0;
        }
        public int SumAProjectionFromASequence()
        {
            string[] words = { "cherry", "apple", "blueberry" };
            //uses Sum to get the total number of characters of all words in the array.
            #region Sum clause
            double totalChars = words.Sum(l => l.Length);
            Console.WriteLine(totalChars);
            #endregion
            return 0;
        }
        public int SumAllElementsInAGroup()
        {
            //uses Sum to get the total units in stock for each product category.
            var productsList = GetProducts();
            #region Sum clause
            var totalProducts = from product in productsList
                             group product by product.Category into g
                             select (Category: g.Key, Count: g.Sum(p => p.UnitsInStock));
            foreach(var product in totalProducts)
            {
                Console.WriteLine($"Category: {product.Category}, Amount of product:{product.Count}");
            }
            #endregion
            return 0;
        }
        #endregion
        #region Min-Max
        #region Min Section
        public int MinOfSequence()
        {
            //uses Min to get the lowest number in an array.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Min clause
            var minOfNumbers = numbers.Min();
            Console.WriteLine("Min of the array is: {0}", minOfNumbers);
            #endregion
            return 0;
        }
        public int MinOfProjection()
        {
            //uses Min to get the length of the shortest word in an array.
            string[] words = { "cherry", "apple", "blueberry" };
            #region Min clause
            var lengthOfShortestWord = words.Min(w => w.Length);
            Console.WriteLine(lengthOfShortestWord);
            #endregion
            return 0;
        }
        public int MinOfGroup()
        {
            //uses Min to get the cheapest price among each category's products.
            var productsList = GetProducts();
            #region Min-clause
            var categories = from product in productsList
                             group product by product.Category into g
                             select (Category: g.Key, Cheapest: g.Min(p => p.UnitPrice));
            foreach(var category in categories)
            {
                Console.WriteLine($"Category: {category.Category}, Cheapest Price: {category.Cheapest}");
            }
            #endregion
            return 0;
        }
        public int MinOfMatchingElements()
        {
            //uses Min to get the products with the cheapest price in each category.
            var products = GetProducts();
            #region Min-clause
            var cheapestProducts = from product in products
                                   group product by product.Category into g
                                   let minPrice = g.Min(p => p.UnitPrice)
                                   select (Category: g.Key, CheapestProducts: g.Where(p => p.UnitPrice == minPrice));
            foreach(var category in cheapestProducts)
            {
                Console.WriteLine("Category: {0}", category.Category);
                foreach(var product in category.CheapestProducts)
                {
                    Console.WriteLine(product);
                }
            }
            #endregion
            return 0;
        }
        #endregion
        #region Max Section
        public int MaxOfSequence()
        {
            // uses Max to get the highest number in an array.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Max-clause
            var maxNumber = numbers.Max();
            Console.WriteLine(maxNumber);
            #endregion
            return 0;
        }
        public int MaxOfProjection()
        {
            // uses Max to get the length of the longest word in an array.
            string[] words = { "cherry", "apple", "blueberry" };
            #region Max-clause
            var lengthOfLongestWord = words.Max(p => p.Length);
            Console.WriteLine(lengthOfLongestWord);
            #endregion
            return 0;
        }
        public int MaxOfGroup()
        {
            // uses Max to get the most expensive price among each category's products.
            var productsList = GetProducts();
            #region Max-clause
            var categories = from product in productsList
                             group product by product.Category into g
                             select (Category: g.Key, MostExpensivePrice: g.Max(p => p.UnitPrice));
            foreach(var category in categories)
            {
                Console.WriteLine($"Category: {category.Category}, The most expensive price: {category.MostExpensivePrice}");
            }
            #endregion
            return 0;
        }
        public int MaxOfMatchingElements()
        {
            //uses Max to get the products with the most expensive price in each category.
            var productsList = GetProducts();
            #region Max-clause
            var categories = from product in productsList
                             group product by product.Category into g
                             let mostExpensivePrice = g.Max(p => p.UnitPrice)
                             select (Category: g.Key, ProductsPrice: g.Where(p => p.UnitPrice == mostExpensivePrice));
            foreach(var category in categories)
            {
                Console.WriteLine($"Category: {category.Category}");
                foreach(var proPrice in category.ProductsPrice)
                {
                    Console.WriteLine(proPrice);
                }
            }
            #endregion
            return 0;
        }
        #endregion
        #endregion
        #region Average/Aggregate
        public int AverageOfSequence()
        {
            //uses Average to get the average of all numbers in an array.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Average-clause
            var averageNumber = numbers.Average();
            Console.WriteLine(averageNumber);
            #endregion
            return 0;
        }
        public int AverageOfProjection()
        {
            //uses Average to get the average length of the words in the array.
            string[] words = { "cherry", "apple", "blueberry" };
            #region Average-clause
            var averageOfLength = words.Average(p => p.Length);
            Console.WriteLine(averageOfLength);
            #endregion
            return 0;
        }
        public int AverageOfGroup()
        {
            // uses Average to get the average price of each category's products.
            var productsList = GetProducts();
            #region Average-clause
            var categories = from product in productsList
                             group product by product.Category into g
                             select (Category: g.Key, AveragePrice: g.Average(p => p.UnitPrice));
            foreach(var category in categories)
            {
                Console.WriteLine($"Category: {category.Category}, Average Price: {category.AveragePrice}");
            }
            #endregion
            return 0;
        }
        public int AggregateValueOfSequence()
        {
            //uses Aggregate to create a running product on the array that calculates the total product of all elements.
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };
            #region Aggregate-clause
            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);
            Console.WriteLine($"Total product of all numbers: {product}");
            #endregion
            return 0;
        }
        public int AggregateValueFromASeedValue()
        {
            //uses Aggregate to create a running account balance that subtracts each withdrawal from the initial balance of 100,
            //as long as the balance never drops below 0.
            double startBalance = 100.0;
            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };
            #region Aggregate-clause
            double endBalance = attemptedWithdrawals.Aggregate(startBalance, 
                (balance, nextWithdrawals) => ((nextWithdrawals <= balance) ? (balance - nextWithdrawals) : balance));
            Console.WriteLine(endBalance);
            #endregion
            return 0;
        }
        #endregion
    }
}
