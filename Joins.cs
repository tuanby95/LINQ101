using LINQ101.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ101
{
    internal class Joins
    {
        private List<Customer> GetCustomers() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;
        public int CrossJoin()
        {
            //use Join to make a new categories list that conclude elements from the given categories string[]
            //that match the product list
            string[] categories = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };
            var productsList = GetProducts();
            #region Join-clause
            var q = from c in categories
                    join p in productsList on c equals p.Category
                    select (Category: c, ProductName: p.ProductName);
            foreach(var v in q)
            {
                Console.WriteLine(v.ProductName + ": " + v.Category);
            }
            #endregion
            return 0;
        }
        public int GroupJoin()
        {
            //Using a group join you can get all the products that match a given category bundled as a sequence.
            string[] categories = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };
            var productsList = GetProducts();
            #region Group Join-clause
            var q = from c in categories
                    join p in productsList on c equals p.Category into ps
                    select (Category: c, Products: ps);
            foreach(var v in q )
            {
                Console.WriteLine(v.Category + ':');
                foreach(var p in v.Products)
                {
                    Console.WriteLine("   " + p.ProductName);
                }
            }
            #endregion
            return 0;
        }
        public int GroupJoinAndCrossJoin()
        {
            //combine group join and cross join
            string[] categories = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };
            #region Join-clause
            var productsList = GetProducts();
            var q = from c in categories
                    join p in productsList on c equals p.Category into ps
                    from p in ps
                    select (Category: c, Products: p.ProductName);
            foreach (var v in q)
            {
                Console.WriteLine(v.Products + ": " + v.Category);
            }
            #endregion
            return 0;
        }
        public int OuterJoin()
        {
            string[] categories = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };
            var productsList = GetProducts();
            var q = from c in categories
                    join p in productsList on c equals p.Category into ps
                    from p in ps.DefaultIfEmpty()
                    select (Category: c, Products: p == null ? "(No products)" : p.ProductName);
            foreach(var v in q)
            {
                Console.WriteLine($"{v.Products}: {v.Category}");
            }
            return 0;
        }
    }
}