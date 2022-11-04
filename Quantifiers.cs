using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Quantifiers
    {        
        private List<Product> GetProducts() => Products.ProductList;
        public int CheckForMatchingElement()
        {
            // uses Any to determine if any of the words in the array contain the substring 'ei'.
            string[] words = { "believe", "relief", "receipt", "field" };
            #region Any-clause
            bool afterEi = words.Any(w => w.Contains("ei"));
            Console.WriteLine("There is a word that contained in the list contains 'ei': {0}", afterEi);
            #endregion
            return 0;
        }
        public int GroupElementsMatchingCondition()
        {
            // uses Any to return a grouped a list of products only for categories that have at least one product that is out of stock.
            var productsList = GetProducts();
            #region group & Any clause
            var productGroups = from product in productsList
                                group product by product.Category into g
                                where g.Any(p => p.UnitsInStock == 0)
                                select (Category: g.Key, Products: g);
            foreach (var group in productGroups)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine($"{product}");
                }
            }
            #endregion
            return 0;
        }
        public int CheckAllElementMatchCondition()
        {
            //uses All to determine whether an array contains only odd numbers.
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };
            bool isOddArray = numbers.All(p => p % 2 == 1);
            Console.WriteLine("The Array contains only odd numbers: {0}", isOddArray);
            return 0;
        }
        public int GroupAllElementsMatchingCondition()
        {
            //uses All to return a grouped a list of products only for categories that have all of their products in stock.
            var productsList = GetProducts();
            #region group & All clause
            var productGroups = from product in productsList
                                group product by product.Category into g
                                where g.Any(p => p.UnitsInStock > 0)
                                select (Category: g.Key, Products: g);
            foreach(var group in productGroups)
            {
                Console.WriteLine($"Category {group.Category}");
                foreach(var product in group.Products)
                {
                    Console.WriteLine(product);
                }
            }
            #endregion
            return 0;
        }
    }
}
