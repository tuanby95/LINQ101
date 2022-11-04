using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    public class Groups
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int GroupByInto()
        {
            //example of using group by and into to create buckets based on remainder of an integer when dividing it by 5
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region group-by-into
            var numberGroups = from number in numbers
                               group number by number % 5 into g
                               select (Remainder: g.Key, Numbers: g);
            foreach(var group in numberGroups)
            {
                Console.WriteLine($"Numbers with remainder of {group.Remainder} when dividing by 5: ");
                foreach(var n in group.Numbers)
                { 
                    Console.WriteLine(n); 
                };
            }
            #endregion
            return 0;
        }
        public int GroupByUsingProperty()
        {
            //uses group by to partition a list of words by their first letter.
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };
            #region group by property
            var wordGroups = from word in words
                             group word by word[0] into g
                             select (FirstLetter: g.Key, Words: g);
            foreach( var g in wordGroups)
            {
                Console.WriteLine($"Words that start with letter {g.FirstLetter}:");
                foreach(var w in g.Words)
                {
                    Console.WriteLine(w);
                }
            }
            #endregion
            return 0;
        }
        public int GroupByUsingKeyProperty()
        {
            //uses group by to partition a list of products by category.
            #region group by key property
            var productsList = GetProducts();
            var orderGroups = from p in productsList
                              group p by p.Category into g
                              select (Category: g.Key, Products: g);
            foreach(var g in orderGroups)
            {
                Console.WriteLine($"Products in {g.Category} category:");
                foreach(var p in g.Products)
                {
                    Console.WriteLine(p);
                }
            }
            #endregion
            return 0;
        }
        public int NestedGroupByQueries()
        {
            //use group by and into nested buckets of orders by customer, year, and month.
            #region nested group
            var customersList = GetCustomers();
            var customersOrderGroups = from c in customersList
                                       select
                                       (
                                       c.CompanyName,
                                       YearGroup: from o in c.Orders
                                                  group o by o.OrderDate.Year into yg
                                                  select
                                                  (
                                                  YearGroup: yg.Key,
                                                  MonthGroups: from o in yg
                                                         group o by o.OrderDate.Month into mg
                                                         select
                                                         (
                                                         MonthGroup: mg.Key,
                                                         Orders: mg
                                                         )
                                                  )
                                       );
            foreach(var ordersByCustomer in customersOrderGroups)
            {
                Console.WriteLine($"Customer name: {ordersByCustomer.CompanyName}");
                foreach (var ordersByYear in ordersByCustomer.YearGroup)
                {
                    Console.WriteLine($"Year: {ordersByYear}");
                    foreach(var ordersByMonth in ordersByYear.MonthGroups)
                    {
                        Console.WriteLine($"Month: {ordersByMonth.MonthGroup}");
                        foreach(var order in ordersByMonth.Orders)
                        {
                            Console.WriteLine("Order: {0}",order);
                        }
                    }
                }
            }
            #endregion
            return 0;
        }
        #region grouping with custom comparer
        public class AnagramEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y) => getCanonicalString(x) == getCanonicalString(y);

            public int GetHashCode(string obj) => getCanonicalString(obj).GetHashCode();

            private string getCanonicalString(string word)
            {
                char[] wordChars = word.ToCharArray();
                Array.Sort<char>(wordChars);
                return new string(wordChars);
            }
        }
        public int GroupingWithCustomComparer()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            var orderGroups = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());

            foreach (var set in orderGroups)
            {
                // The key would be the first item in the set
                foreach (var word in set)
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine("...");
            }
            return 0;
        }
        public int NestedGroupingWithCustomComparer()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            var orderGroups = anagrams.GroupBy(
                    w => w.Trim(),
                    a => a.ToUpper(),
                    new AnagramEqualityComparer()
                );
            foreach(var set in orderGroups)
            {
                Console.WriteLine(set.Key);
                foreach(var word in set)
                {
                    Console.WriteLine(word);
                }
            }
            return 0;
        }
        #endregion
    }
}
