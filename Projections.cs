using LINQ101.DataSources;

namespace LINQ101
{
    public class Projections
    {
        private List<Customer> GetCustoners() => Customers.CustomerList;
        private List<Product> GetProducts() => Products.ProductList;

        private int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        private string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public int SelectClause()
        {
            //use Select to produce a sequence of ints one higher than those in an existing array of ints.
            #region select-clause
            var numPlusOne = from numb in numbers
                             select numb + 1;
            foreach(var n in numPlusOne)
            {
                Console.WriteLine(n);
            }
            #endregion
            return 0;
        }
        public int SelectSingleProperty()
        {
            //use Select to return a sequence of just the name property of the names of a list of products
            var productlist = GetProducts();
            #region select-property
            var productNameList = from product in productlist
                                  select product.ProductName;
            foreach (var name in productNameList)
            {
                Console.WriteLine(name);
            }
            #endregion
            return 0;
        }
        public int TransfromWithSelect()
        {
            //use select to produce a sequence of strings representing the text version of the numbers array
            //initial a string array containt the text version of the number
            #region select-clause
            var textNumbers = from numb in numbers
                              select strings[numb];
            foreach(var number in textNumbers)
            {
                Console.WriteLine(number);
            }
            #endregion
            return 0;
        }
        public int SelectAnonymousType()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            #region select to create anonymous-type
            var upperLowerWords = from w in words
                             select new {Upper = w.ToUpper(), Lower = w.ToLower()};
            foreach(var word in upperLowerWords)
            {
                Console.WriteLine(word);
            }
            #endregion
            return 0;
        }
        public int SelectToCreateNewType()
        {
            //uses select to produce a sequence containing text representations of digits and whether their length is even or odd
            #region select to create new type
            var digitOddEvens = from numb in numbers
                                select new { Digit = strings[numb], Even = (numb % 2 == 0) };
            foreach(var d in digitOddEvens)
            {
                Console.WriteLine(d);
            }
            #endregion
            return 0;
        }
        public int SelectToCreateNewTypeVer2()
        {
            #region select-to-create-new-type
            var digitOddEvens = from numb in numbers
                                select (Digit: strings[numb], Even: (numb % 2 == 0));
            foreach(var d in digitOddEvens)
            {
                Console.WriteLine($"Digit: {d.Digit} is {(d.Even? "even" : "odd")}");
            }
            #endregion
            return 0;
        }
        public int SelectASubsetOfProperties()
        {
            //uses select to produce a sequence containing some properties of Products,
            //including UnitPrice which is renamed to Price in the resulting type.
            var producsList = GetProducts();
            #region select-a-subset
            var newProductsList = from prod in producsList
                                  select (ProductName: prod.ProductName, Price: prod.UnitPrice);
            foreach(var p in newProductsList)
            {
                Console.WriteLine(p);
            }
            #endregion
            return 0;
        }
        public int SelectWithIndex()
        {
            //uses an indexed Select clause to determine if the value of ints in an array match their position in the array
            #region Select-clause
            var numbInPlace = numbers.Select((value, index) => (Number: value, inPlace : (value == index)));
            foreach(var num in numbInPlace)
            {
                Console.WriteLine(num);
            }
            #endregion
            return 0;
        }
        public int SelectCombineWithWhere()
        {
            //combines select and where to make a simple query that returns the text form of each digit less than 5
            #region select combine with where
            var newResult = from number in numbers
                            where number < 5
                            select strings[number];
            foreach(var item in newResult)
            {
                Console.WriteLine(item);
            }
            #endregion
            return 0;
        }
        public int SelectMultipleInput()
        {
            // uses a compound from clause to make a query that returns all pairs of numbers
            // from both arrays such that the number from numbersA is less than the number from numbersB
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            #region select
            var Result = from numA in numbersA
                         from numB in numbersB
                         where numA < numB
                         select (numA, numB);
            foreach(var n in Result)
            {
                Console.WriteLine(n);
            }
            #endregion
            return 0;
        }
        public int SelectFromRelatedInput()
        {
            //uses a compound from clause to select all orders where the order total is less than 500.00
            var customersList = GetCustoners();
            #region select-clause
            var customers = from c in customersList
                            where c.Orders.Any(o => o.Total < 500M)
                            select (c.CustomerID, c.Orders);
            foreach(var i in customers)
            {
                Console.WriteLine(i);
            }
            #endregion
            return 0;
        }
        public int SelectFromRelatedInputVer2()
        {
            //uses a compound from clause to select all orders where the order total is less than 500.00
            var customers = GetCustoners();
            #region select-clause
            var customerOrdersList = from c in customers
                          from o in c.Orders
                          where o.Total < 500M
                          select (Customer: c.CustomerID, OrderID: o.OrderID, Date: o.OrderDate);
            foreach(var i in customerOrdersList)
            {
                Console.WriteLine(i);
            }
            #endregion
            return 0;
        }
        public int SelectWithWhereClause()
        {
            //uses a compound from clause to select all orders where the order was made in 1998 or later.
            var customers = GetCustoners();
            #region select with where clause
            var orderlist = from cus in customers
                            from order in cus.Orders
                            where order.OrderDate >= new DateTime(1998, 1, 1)
                            select (order.OrderID, order.OrderDate, order.Total);
            foreach(var o in orderlist)
            {
                Console.WriteLine(o);
            }
            #endregion
            return 0;
        }
        public  int SelectWithWhereAndAssignent()
        {
            // uses a compound from clause to select all orders where the order total is greater than 2000.00 and
            //uses from assignment to avoid requesting the total twice
            var customersList = GetCustoners();
            #region select clause
            var ordersList = from customer in customersList
                             from order in customer.Orders
                             where order.Total > 2000M
                             select  (Customer: customer.CustomerID, Order: order.OrderID, Price: order.Total);
            foreach(var o in ordersList)
            {
                Console.WriteLine($"Customer {o.Customer} - Order ID: {o.Order} - Price: {o.Price}");
            }
            #endregion
            return 0;
        }
        public int SelectWithMultipleWhereClause()
        {
            //uses multiple from clauses so that filtering on customers can be done before selecting their orders.
            //This makes the query more efficient by not selecting and then discarding orders for customers outside of Washington
            //select all customer that have orders's date later than 1997
            var customers = GetCustoners();
            var cutOffDate = new DateTime(1997, 1, 1);
            #region select clause
            var customerList = from cus in customers
                               where cus.Region == "WA"
                               from order in cus.Orders
                               where order.OrderDate > cutOffDate
                               select (Customer: cus.CustomerID, Order: order.OrderID);
            foreach(var customer in customerList)
            {
                Console.WriteLine($"Customer {customer.Customer} - Order ID: {customer.Order}");
            }
            #endregion
            return 0;
        }
        public int SelectManyWithIndex()
        {
            //uses an indexed SelectMany clause to select all orders,
            //while referring to customers by the order in which they are returned from the query.
            var customers = GetCustoners();
            #region using indexed SelectMany syntax
            var orderList = customers.SelectMany(
                (cust, custIndex) => 
                cust.Orders.Select(o => "Customer #" + (custIndex + 1) + " has an order with Order ID " + o.OrderID)
                );
            foreach(var order in orderList)
            {
                Console.WriteLine(order);
            }
            #endregion
            return 0;
        }
    }
}
