using Northwind.Entities;
using System.Linq;
using static Northwind.DataLists;
namespace Northwind
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Easy
            #region Retrieve all products with a unit price greater than $50.
            //var products = Products.Where(product => product.UnitPrice > 50);


            //products = from product in Products
            //           where product.UnitPrice > 50
            //           select product;

            //foreach (var product in products)
            //Console.WriteLine(product);
            #endregion

            #region List the names of all customers from London.
            //var londonCustomerNames = Customers.Where(customer => customer.City == "London").Select(customer => customer.CompanyName);

            //londonCustomerNames = from customer in Customers
            //                      where customer.City == "London"
            //                      select customer.CompanyName;

            //foreach (var customerName in londonCustomerNames)
            //    Console.WriteLine(customerName);
            #endregion

            #region Find all orders shipped by "Speedy Express".
            /// There is a relationship between Shipper (PK => ShipperID) and Order (FK => ShipVia)

            /// Join With Fluent Syntax is more complex and less readable than Query Syntax
            /// It has Outer Entity (Orders)
            /// Inner Entity (Shippers)
            /// Outer Key Selector (FK Which Order Entity Has => ShipVia)
            /// Inner Key Selector (PK Which Shipper Entity Has => ShipperID)
            /// Result Selector => (order, shipper) => new { Order = order, Shipper = shipper }

            //var orders = Orders.Join(Shippers,
            //                        order => order.ShipVia,
            //                        shipper => shipper.ShipperID,
            //                        (order, shipper) => new { Order = order, Shipper = shipper })
            //                   .Where(x => x.Shipper.CompanyName == "Speedy Express")
            //                   .Select(x => x.Order);

            //var orders = from order in Orders
            //         join shipper in Shippers
            //         on order.ShipVia equals shipper.ShipperID
            //         where shipper.CompanyName == "Speedy Express"
            //         select order;

            //foreach (var order in orders) 
            //    Console.WriteLine(order);
            #endregion

            #region Get the total number of orders placed by customer "BONAP".
            //var ordersCount = Orders.Where(order => order.CustomerID == "BONAP").Count();

            //ordersCount = (from order in Orders
            //               where order.CustomerID == "BONAP"
            //               select order).Count();

            //Console.WriteLine(ordersCount);
            #endregion

            #region List all employees who are managers.
            // Self Relationship represented at the FK => ReportsTo
            //var managers = Employees.Where(employee => Employees.Any(e => e.ReportsTo == employee.EmployeeID));

            //managers = from employee in Employees
            //           where Employees.Any(e => e.ReportsTo == employee.EmployeeID)
            //           select employee;

            /// There is another way to get the same result by getting all managers ids from ReportsTo Column (Keep in Mind it is nullable)
            //var managerIds = Employees.Where(e => e.ReportsTo.HasValue)
            //                          .Select(e => e.ReportsTo.Value)
            //                          .Distinct(); // Distinct because there will be redundant values

            /// That will get us a list of all managers ids , now we need the data for each one of them
            /// So we will check if the managerIds list contains the id of the employee from Employee List
            //var managers = Employees.Where(employee => managerIds.Contains(employee.EmployeeID));

            /// The Query Syntax Version
            //var managerIds = (from e in Employees
            //                  where e.ReportsTo.HasValue
            //                  select e.ReportsTo.Value).Distinct();

            //var managers = from employee in Employees
            //               where managerIds.Contains(employee.EmployeeID)
            //               select employee;

            //foreach (var manager in managers)
            //    Console.WriteLine(manager);
            #endregion

            #region Find products that are discontinued.
            //var discontinuedProducts = Products.Where(p => p.Discontinued);

            //foreach (var product in discontinuedProducts)
            //{
            //    Console.WriteLine(product);
            //}
            #endregion

            #region Retrieve the names and phone numbers of all suppliers.
            //var suppliers = Suppliers.Select(s => new { name = s.CompanyName, PhoneNumber = s.Phone });

            //foreach (var supplier in suppliers)
            //{
            //    Console.WriteLine(supplier);
            //}
            #endregion

            #region Get all orders placed in the year 1996.
            //var orders = Orders.Where(o => o.OrderDate.Year == 1996);

            //foreach (var order in orders)
            //{
            //    Console.WriteLine(order);
            //}
            #endregion

            #region  Find all customers in the "USA".
            //var usaCustomers = Customers.Where(c => c.Country == "USA");

            //foreach (var customer in usaCustomers)
            //{
            //    Console.WriteLine(customer);
            //}
            #endregion

            #region  List products that belong to category "Beverages".
            //var products = Products.Join(Categories,
            //    p => p.CategoryID,
            //    c => c.CategoryID,
            //    (p, c) => new { Product = p, Category = c })
            //    .Where(x => x.Category.CategoryName == "Beverages")
            //    .Select(x => x.Product);

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product);
            //}
            #endregion

            #region Retrieve orders with a freight cost less than 10.
            //var orders = Orders.Where(o => o.Freight < 10);

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get the names and titles of all employees.
            //var employees = Employees.Select(e => new { Name = e.FirstName + ' ' + e.LastName, Title = e.Title });

            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find suppliers from "Germany".
            //var suppliers = Suppliers.Where(s => s.Country == "Germany");

            //foreach (var item in suppliers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all products with quantities between 10 and 50.
            //var products = Products.Where(p => p.UnitsInStock >= 10 && p.UnitsInStock <= 50);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve orders that were shipped but not yet delivered.
            //var orders = Orders.Where(o => o.ShippedDate.HasValue && o.ShippedDate < o.RequiredDate);

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get the total number of products in each category.
            //var productsGroupedByCategories = Products.GroupBy(p => p.CategoryID).Select(g => new { CategoryId = g.Key, ProductCount = g.Count() });

            //foreach (var item in productsGroupedByCategories)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all orders placed by employee with ID 5.
            //var ordersByEmploee5 = Orders.Where(o=>o.EmployeeID == 5);

            //foreach (var item in ordersByEmploee5)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find the name of the supplier with the highest ID.
            //int maxId = Suppliers.Max(s => s.SupplierID);

            //var supplierNameWithMaxId=Suppliers.Where(s=> s.SupplierID == maxId).Select(s => s.CompanyName).FirstOrDefault();
            //Console.WriteLine(supplierNameWithMaxId);
            #endregion

            #region Retrieve products that have "Box" in their quantity per unit description.
            //var products = Products.Where(p => p.QuantityPerUnit.ToLower().Contains("box"));

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region  List all customers from "Germany".
            //var customers = Customers.Where(c => c.Country == "Germany");

            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find all products that have never been ordered.
            //var orderedProductsIds = OrderDetails.Select(od => od.ProductID).Distinct().ToList();

            //var neverOrderdProducts = Products.Where(p => !orderedProductsIds.Contains(p.ProductID));

            //foreach (var item in neverOrderdProducts)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get all orders with a freight cost greater than 50.
            //var orderes = Orders.Where(o => o.Freight > 50);

            //foreach (var item in orderes)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve names of all categories.
            //var CategoriesNames = Categories.Select(c => c.CategoryName);

            //foreach (var item in CategoriesNames)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all orders where the ship city is "Seattle".
            //var orders = Orders.Where(o => o.ShipCity == "Seattle");

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find the employees who have "Sales" in their title.
            //var employees = Employees.Where(e => e.Title.ToLower().Contains("sales"));

            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve orders that were placed in the month of June.
            //var JuneOrderes = Orders.Where(o => o.OrderDate.Month == 6);

            //foreach (var item in JuneOrderes)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get the names and phone numbers of suppliers from "Italy".
            //var suppliers = Suppliers.Where(s => s.Country == "Italy").Select(s => new { name = s.CompanyName, phone = s.Phone });

            //foreach (var item in suppliers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all products with unit prices less than 20.
            //var products = Products.Where(p => p.UnitPrice < 20);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find orders that were shipped in 1997.
            //var orders = Orders.Where(o => o.ShippedDate?.Year == 1997);

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve the names of all customers who have placed more than 5 orders.
            //var customersIds = Orders.GroupBy(o => o.CustomerID).Where(g => g.Count() > 5).Select(g => g.Key);

            //var customers = Customers.Where(c => customersIds.Contains(c.CustomerID)).Select(c=>new { name = c.CompanyName });

            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List products with no quantity on order.
            //var products = Products.Where(p => p.UnitsOnOrder == 0);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region  Get all categories with more than 10 products.
            //var categoriesIds = new HashSet<int?>(
            //    Products.GroupBy(p => p.CategoryID).Where(g => g.Count() > 10).Select(g=>g.Key)
            //    );

            //var categories= Categories.Where(c=>categoriesIds.Contains(c.CategoryID));

            //foreach (var item in categories)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find the customer with the most recent order.
            //var order = Orders.OrderByDescending(o => o.OrderDate).FirstOrDefault();

            //var customer = Customers.FirstOrDefault(c => c.CustomerID == order?.CustomerID);

            //Console.WriteLine(customer);
            #endregion

            #region Retrieve employees who work in "Sales".
            //var salesEmployees = Employees.Where(e => e.Title.ToLower().Contains("sales"));

            //foreach (var item in salesEmployees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all products with a reorder level less than 10.
            //var products = Products.Where(p => p.ReorderLevel < 10);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find orders with a ship country of "USA" and a freight cost less than $20.
            //var orderes = Orders.Where(o => o.ShipCountry == "USA" && o.Freight < 20);

            //foreach (var item in orderes)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get the names of suppliers who have a fax number.
            //var suppliers = Suppliers.Where(s => s.Fax is not null).Select(s => s.CompanyName);

            //foreach (var item in suppliers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all orders placed in the first quarter of 1996.
            //var orders = Orders.Where(o => o.OrderDate.Month <= 3);
            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve products that have a unit price between $20 and $50.
            //var products = Products.Where(p => p.UnitPrice >= 20 && p.UnitPrice <= 50);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region  Find customers who have a postal code starting with "9".
            //var customers = Customers.Where(c => c.PostalCode.StartsWith('9'));

            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all employees with their address details.
            //var employees = Employees.Select(e => new { Name = e.FirstName + ' ' + e.LastName, address = e.Address });

            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get all orders where the ship region is "CA".
            //var orders = Orders.Where(o => o.ShipRegion == "CA");

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find all categories with at least one product in stock.
            //var productsInStockCategoriesIds = new HashSet<int?>(Products.Where(p => p.UnitsInStock > 0).Distinct().Select(p => p.CategoryID));

            //var categories = Categories.Where(c => productsInStockCategoriesIds.Contains(c.CategoryID));

            //foreach (var item in categories)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region  Retrieve the names and cities of customers who live in "USA".
            //var customers = Customers.Where(c => c.Country == "USA").Select(c => new { name = c.CompanyName, city = c.City });

            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region  List products supplied by supplier with ID 10.
            //var products = Products.Where(p => p.SupplierID == 10);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find all orders where the ship name contains "Express".
            //var orders = Orders.Where(o => o.ShipName.ToLower().Contains("express"));

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get the details of products with more than 20 units in stock.
            //var products = Products.Where(p => p.UnitsInStock > 20);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve all orders where the order date is in 1995.
            //var orders = Orders.Where(o => o.OrderDate.Year == 1995);

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all suppliers from "Canada" who have a phone number starting with "416".
            //var suppliers = Suppliers.Where(s => s.Country == "Canada" && s.Phone.StartsWith("416"));

            //foreach (var item in suppliers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find products that have been ordered more than 50 times.
            //var frequentlyOrderedProductIds = new HashSet<int>
            //    (
            //    OrderDetails
            //    .GroupBy(od => od.ProductID)
            //    .Where(g => g.Sum(od => od.Quantity) > 50)
            //    .Select(g => g.Key));

            //var frequentlyOrderedProducts = Products
            //    .Where(p => frequentlyOrderedProductIds.Contains(p.ProductID));

            //foreach (var product in frequentlyOrderedProducts)
            //{
            //    Console.WriteLine(product);
            //}

            #endregion

            #region  Get the names of all employees who are not managers.
            //var managerIds =new HashSet<int>(
            //     Employees.Where(e => e.ReportsTo.HasValue)
            //                          .Select(e => e.ReportsTo.Value)
            //                          .Distinct());


            //var notManagers = Employees.Where(employee => !managerIds.Contains(employee.EmployeeID)).Select(e=>new { name = e.FirstName + ' ' + e.LastName });

            //foreach (var item in notManagers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List orders where the ship country is "Mexico".
            //var orders = Orders.Where(o => o.ShipCountry == "Mexico");
            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve all products with a quantity per unit description containing "bottle".
            //var products = Products.Where(p => p.QuantityPerUnit.ToLower().Contains("bottle"));

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find the top 5 products with the highest unit price.
            //var products = Products.OrderByDescending(p => p.UnitPrice).Take(5);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get all customers who have a contact title of "Owner".
            //var customers = Customers.Where(c => c.ContactTitle.ToLower().Contains("owner"));

            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region  List all employees who have their last name starting with "S".
            //var employees = Employees.Where(e => e.LastName.StartsWith('S'));
            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve orders placed in the month of December.
            //var orders = Orders.Where(o => o.OrderDate.Month == 12);

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find products that are neither discontinued nor have a reorder level of 0.
            //var products = Products.Where(p => !p.Discontinued && p.ReorderLevel != 0);

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get the names of suppliers who have their country listed as "UK".
            //var suppliers = Suppliers.Where(s => s.Country == "UK").Select(s=>s.CompanyName);
            //foreach (var item in suppliers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all orders with a ship city of "London" and a freight cost greater than $30.
            //var orders = Orders.Where(o => o.ShipCity == "London" && o.Freight > 50);

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve all employees who were hired in 1997.
            //var employees = Employees.Where(e => e.HireDate.Contains("1997"));

            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find products that have been ordered by more than 10 different customers.
            //var productsIds = new HashSet<int>(
            //    Orders.Join(OrderDetails,
            //    o=>o.OrderID,
            //    od=>od.OrderID,
            //    (o,od)=>new {productId=od.ProductID , customerID = o.CustomerID})
            //    .GroupBy(x=>x.productId)
            //    .Where(g=>g.Select(x=>x.customerID).Distinct().Count()>10)
            //    .Select(x=>x.Key)
            //    );

            //var products = Products.Where(p=>productsIds.Contains(p.ProductID));

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Get all categories that do not have any discontinued products.
            //var categoriesIds = new HashSet<int?>(
            //    Products.GroupBy(p => p.CategoryID).Where(g => g.All(x => !x.Discontinued)).Select(g => g.Key));

            //var categories= Categories.Where(c=>categoriesIds.Contains(c.CategoryID));

            //foreach (var item in categories)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List all customers who have a region specified.
            //var customers = Customers.Where(c => !string.IsNullOrEmpty(c.Region));

            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Retrieve products where the unit price is greater than the average unit price.
            //var products = Products.Where(p => p.UnitPrice > Products.Average(p => p.UnitPrice));

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Find the supplier with the most products.
            //var supplierId = Products.GroupBy(p => p.SupplierID).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            //var suppleier=Suppliers.FirstOrDefault(s=>s.SupplierID == supplierId);

            //Console.WriteLine(suppleier);
            #endregion

            #region Get all orders where the order date is after January 1, 1996.
            //var orders = Orders.Where(o => o.OrderDate > new DateTime(1996-1-1));

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region List products with a unit price that is a multiple of 5.
            //var products = Products.Where(p => p.UnitPrice % 5 == 0);
            #endregion

            #region Retrieve the names of customers who have placed at least 3 orders.
            //var customerIds = Orders.GroupBy(o => o.CustomerID).Where(g => g.Count() >= 3).Select(g => g.Key).Distinct();

            //var customers = Customers.Where(c => customerIds.Contains(c.CustomerID));
            #endregion

            #region Find all orders shipped by "United Package".
            //var orders = Orders.Join(Shippers,
            //    o => o.ShipVia,
            //    sh => sh.ShipperID,
            //    (o, sh) => new { order = o, shipper = sh })
            //    .Where(x => x.shipper.CompanyName == "United Package")
            //    .Select(x => x.order);

            #endregion

            #region  Get the details of orders that were shipped in "Paris".
            //var orders = Orders.Where(o => o.ShipCity == "Paris");
            #endregion

            #region List products that have been discontinued and have a unit price greater than $30.
            //var products = Products.Where(p => p.Discontinued && p.UnitPrice > 30);
            #endregion

            #region  Retrieve employees who have not shipped any orders.
            //var employeesIds = Orders.Select(o => o.EmployeeID).Distinct();

            //var employees=Employees.Where(e=>!employeesIds.Contains(e.EmployeeID));
            #endregion

            #region  Find customers who have orders with a discount applied.
            //var customersIds = Orders.Join(OrderDetails,
            //    o => o.OrderID,
            //    od => od.OrderID,
            //    (o, od) => new { order = o, orderDetials = od })
            //    .Where(x => x.orderDetials.Discount > 0)
            //    .Select(x => x.order.CustomerID)
            //    .Distinct();

            //var customers= Customers.Where(c=>customersIds.Contains(c.CustomerID));

            #endregion

            #region Get the top 3 most expensive products.
            //var products = Products.OrderByDescending(p => p.UnitPrice).Take(3);
            #endregion

            #region List all suppliers with a home page.
            //var suppliers = Suppliers.Where(s => string.IsNullOrEmpty(s.HomePage));
            #endregion

            #region  Retrieve orders where the freight cost is between $10 and $50.
            //var orders = Orders.Where(o => o.Freight >= 10 && o.Freight <= 50);
            #endregion

            #region  Find products supplied by a supplier with the name "Exotic Liquids".
            //var products = Products.Join(Suppliers,
            //    p => p.SupplierID,
            //    s => s.SupplierID,
            //    (p, s) => new { product = p, supplier = s })
            //    .Where(x => x.supplier.CompanyName == "Exotic Liquids")
            //    .Select(x => x.product);
            #endregion

            #region  Get all orders that were required before the order date.
            //var orders = Orders.Where(o => o.RequiredDate < o.OrderDate);
            #endregion

            #region List products that have been ordered at least once in each year of the 1990s.

            #endregion

            #region Retrieve all orders where the ship city is "Seattle" or "Portland".
            //var orders = Orders.Where(o => o.ShipCity == "Seattle" || o.ShipCity == "Portland");
            #endregion

            #region Find employees who have more than one phone number listed.
            //var employeesWithMultiplePhoneNumbers = Employees
            //  .Where(e => !string.IsNullOrEmpty(e.HomePhone) && !string.IsNullOrEmpty(e.Extension));
            #endregion

            #region Get the details of orders placed by the customer "ANATR".
            //var ordersIds = Orders.Join(Customers,
            //    o => o.CustomerID,
            //    c => c.CustomerID,
            //    (o, c) => new { order = o, customer = c })
            //    .Where(x => x.customer.CompanyName == "ANATR")
            //    .Select(x => x.order.OrderID);

            //var orderDetails=OrderDetails.Where(od=>ordersIds.Contains(od.OrderID));
            #endregion

            #region List products with a quantity per unit description that includes "can".
            //var products = Products.Where(p => p.QuantityPerUnit.ToLower().Contains("can"));
            #endregion

            #region Retrieve the names of all customers who have their contact name starting with "A".
            //var customers = Customers.Where(c => c.ContactName.StartsWith("A")).Select(c => c.CompanyName);
            #endregion

            #region Find all products with a unit price between $15 and $25.
            //var products = Products.Where(p => p.UnitPrice >= 15 && p.UnitPrice <= 25);
            #endregion

            #region Get all orders that were shipped in the year 1997 but required before 1996.
            //var orders = Orders.Where(o => o.ShippedDate.HasValue ? o.ShippedDate.Value.Year == 1997 : false && o.RequiredDate.Year < 1996);
            #endregion

            #region List all categories with at least one product that is not discontinued.
            //var categoriesIds = Products.GroupBy(p => p.CategoryID).Where(g => g.Any(p => !p.Discontinued)).Select(g => g.Key);

            //var categories = Categories.Where(c=>categoriesIds.Contains(c.CategoryID));
            #endregion


            #region  Retrieve the names of suppliers who do not have a fax number.
            //var suppliers = Suppliers.Where(s => string.IsNullOrEmpty(s.Fax)).Select(s => s.CompanyName);
            #endregion

            #region  Find customers who live in cities starting with "S".
            //var customers = Customers.Where(c => c.City.StartsWith('S'));
            #endregion

            #region Get the total number of products for each supplier
            //var productsNumber = Products.GroupBy(p => p.SupplierID).Select(g => new {supplierID=g.Key , productsNumber= g.Count() });
            #endregion

            #region List all orders where the freight cost is exactly $15.
            //var orders = Orders.Where(o => o.Freight == 15);
            #endregion

            #region Retrieve employees who have a title containing "Manager".
            //var employees = Employees.Where(e => e.Title.ToLower().Contains("manager"));
            #endregion

            #region Find products with a unit price that is not an integer.
            //var products = Products
            //    .Where(p => p.UnitPrice % 1 != 0);
            #endregion

            #region Get the names of all employees whose last name is "Davies".
            //var employees = Employees.Where(e => e.LastName == "Davies").Select(e => e.FirstName);
            #endregion

            #region List all orders shipped by "Federal Shipping".
            //var shipperId = Shippers.FirstOrDefault(sh => sh.CompanyName == "Federal Shipping")?.ShipperID;

            //var orders=Orders.Where(o=>o.ShipVia == shipperId);
            #endregion

            #region Retrieve products with a unit price less than $25 and greater than $10.
            //var products = Products.Where(p => p.UnitPrice < 25 && p.UnitPrice > 10);

            #endregion

            #region Find all customers with the same city as "Berlin".
            //var customers = Customers.Where(c => c.City == "Berlin");
            #endregion

            #region Get the details of orders where the required date is within a week of the order date.
            //var ordersIds = Orders.Where(o => Math.Abs((o.RequiredDate - o.OrderDate).Days) <= 7).Select(o => o.OrderID);

            //var orderDetails=OrderDetails.Where(od=>ordersIds.Contains(od.OrderID));
            #endregion

            #region List all products that have been ordered but have a quantity per unit of "6 boxes".
            //var products = Products.Where(p => p.QuantityPerUnit.ToLower().Contains("6 boxes"));
            #endregion

            #endregion Easy

            #region Medium

            #region List all products whose unit price is higher than the average unit price of all products.
            //var products= Products.Where(p=>p.UnitPrice> Products.Average(p=>p.UnitPrice));
            #endregion

            #region Retrieve the top 5 customers who have placed the highest number of orders.
            //var customersIds = Orders.GroupBy(o => o.CustomerID).OrderByDescending(g => g.Count()).Select(g => g.Key);

            //var customers = Customers.Where(c=>customersIds.Contains(c.CustomerID));
            #endregion

            #region Find all employees who have processed orders in more than 3 different countries.
            //var employeesIds = Orders.GroupBy(o => o.EmployeeID).Where(g.Select(o => o.ShipCountry).Distinct().Count() > 3).Select(g => g.Key);
            //var employees= Employees.Where(e=>employeesIds.Contains(e.EmployeeID));
            #endregion

            #region Get the total number of orders shipped by each shipper.
            //var countOfOrdersPerShipper = Orders.GroupBy(o => o.ShipVia).Select(g => new { shipper = g.Key, NoOrders = g.Count() });
            #endregion

            #region  List all products that have been ordered more than the average quantity ordered per product.
            //var averageQuantityOrdered = OrderDetails.Average(od => od.Quantity);

            //var productsIds= OrderDetails.GroupBy(g=>g.ProductID).Where(g=>g.Sum(g=>g.Quantity) > averageQuantityOrdered).Select(g=>g.Key);

            //var products = Products.Where(p=>productsIds.Contains(p.ProductID));
            #endregion

            #region Retrieve the names of all customers who have ordered products from more than 5 different categories.   
            #endregion

            #region  Find suppliers that have provided products in more than 3 different categories.
            //var suppliersIds = Products.GroupBy(p => p.SupplierID)
            //    .Where(g => g.Select(p => p.CategoryID).Distinct().Count() > 3)
            //    .Select(g => g.Key);

            //var suppliers = Suppliers.Where(s=>suppliersIds.Contains(s.SupplierID));
            #endregion

            #region Get the details of the order with the maximum freight cost.
            //var orderId = Orders.OrderByDescending(o => o.Freight).Select(o => o.OrderID).FirstOrDefault();
            //var orderDetail = OrderDetails.FirstOrDefault(od => od.OrderID == orderId);
            #endregion

            #region List all employees who have shipped orders to more than 10 different cities.
            //var employeesIds = Orders.GroupBy(e => e.EmployeeID)
            //    .Where(g => g.Select(o => o.ShipCity).Distinct().Count() > 10).Select(g => g.Key);

            //var employees = Employees.Where(e=>employeesIds.Contains(e.EmployeeID));
            #endregion

            #region Retrieve all orders that were placed by customers from the same country as the employee who processed them.
            //var customersIds = Customers.Join(Employees,
            //    c => c.Country,
            //    e => e.Country,
            //    (c, e) => c.CustomerID);

            //var orderCustomersIds= Orders.Where(o=>customersIds.Contains(o.CustomerID)).Select(o=> o.CustomerID);

            //var orders = Orders.Where(o => orderCustomersIds.Contains(o.CustomerID));
            #endregion

            #region Find the products that have the highest average discount applied.
            //var  productWithHighestAvgDiscount = OrderDetails
            // .GroupBy(od => od.ProductID) 
            // .Select(g => new
            // {
            //     ProductID = g.Key,
            //     AvgDiscount = g.Average(od => od.Discount) 
            // })
            // .OrderByDescending(p => p.AvgDiscount) 
            // .FirstOrDefault();
            #endregion

            #region Get the total number of products supplied by each supplier.
            //var supplierProductCounts = Products
            //.GroupBy(p => p.SupplierID) 
            //.Select(g => new
            //{
            //    SupplierID = g.Key,
            //    ProductCount = g.Count() 
            //});
            #endregion

            #region List all orders where the total freight cost exceeds the average freight cost of all orders.
            //var orders = Orders.Where(o => o.Freight > Orders.Average(o => o.Freight));
            #endregion

            #region Retrieve the names and addresses of all customers who have not placed any orders.
            //var customersIds = Orders.Select(o => o.CustomerID).Distinct();

            //var customers = Customers.Where(c=>!customersIds.Contains(c.CustomerID));
            #endregion

            #region Find the employee with the most recent hire date.
            //var employee = Employees.OrderByDescending(e => e.HireDate).FirstOrDefault();
            #endregion

            #region Get all orders that were shipped on the same date they were ordered.
            //var orders = Orders.Where(o => o.OrderDate == o.ShippedDate);
            #endregion

            #region  List all products with a unit price that is greater than the median unit price.
            //var sortedProducts = Products.OrderBy(p=>p.UnitPrice).ToList();
            //int count = sortedProducts.Count();
            //decimal medianUnitPrice=0;

            //if (count % 2 == 0)
            //    medianUnitPrice = (decimal)(sortedProducts[count / 2 - 1].UnitPrice + sortedProducts[count / 2].UnitPrice);
            //else
            //    medianUnitPrice = (decimal)sortedProducts[count / 2].UnitPrice;

            //var products = Products.Where(p => p.UnitPrice > medianUnitPrice);
            #endregion

            // Retrieve the average freight cost for each shipper.

            // Find suppliers that have their contact title starting with "Sales".

            // Get the names of all customers who have ordered products with a unit price greater than $100.

            // List products that have a reorder level higher than the average reorder level of all products.

            // Retrieve the top 3 cities with the most customers.

            // Find orders that have a freight cost below the average freight cost for the year 1997.

            // Get the details of the orders shipped by "Speedy Express" in 1996.

            // List all products with a quantity per unit that contains the word "Pack".

            // Retrieve the names of employees who have processed orders in more than 2 different regions.

            // Find the supplier with the most products that have been ordered more than 50 times.

            // Get the total sales amount for each customer.

            // List all customers who have their postal code starting with "9" and have ordered products from more than 3 different categories.

            // Retrieve the average unit price of products in the "Beverages" category.

            // Find the product with the highest unit price and list its supplier details.

            // Get all orders that were placed by customers who have the same contact name as the employee who processed them.

            // List the names of customers and the number of orders they have placed in the year 1996.

            // Retrieve all products with a unit price greater than $30 and with quantities in stock less than the average.

            // Find all employees who have processed orders with a total freight cost above $100.

            // Get the total number of products in each category and list them in descending order.

            // List all orders where the total freight cost is above the average freight cost for orders shipped by "United Package".

            // Retrieve the names of suppliers who have provided products in the "Seafood" category.

            // Find all products that have been ordered in the last 6 months.

            // Get the names of customers who have ordered products supplied by more than 5 different suppliers.

            // List the total number of orders placed by each customer and sort by descending order count.

            // Retrieve employees who have shipped orders to cities in more than 3 different countries.

            // Find the products that are in stock but have never been ordered.

            // Get the total freight cost for each shipper and list them in ascending order.

            // List all categories that have at least one product with a unit price above the average for its category.

            // Retrieve the names and addresses of suppliers who have shipped products to "Paris".

            // Find the customers with the highest average order amount.

            // Get all products that have a unit price less than the average unit price and have never been discontinued.

            // List all orders where the shipping address is in a country that has more than 3 suppliers.

            // Retrieve the names of employees who have processed orders for products in the "Snacks" category.

            // Find the suppliers that have their company name containing the word "Deluxe".

            // Get the details of orders that were shipped to "Tokyo" and have a freight cost above the average.

            // List the products with the highest quantity ordered for each category.

            // Retrieve the names of customers who have not ordered any products from the "Seafood" category.

            // Find all employees who have shipped orders with a total freight cost of less than $20.

            // Get the total number of orders placed by each customer and filter for those with more than 10 orders.

            // List all products that are supplied by suppliers with the highest ID.

            // Retrieve the names and addresses of customers who have ordered products from more than 3 different categories.

            // Find the product with the lowest unit price and list its supplier details.

            // Get all orders where the order date is before the ship date.

            // List all suppliers who have provided products with a unit price above $50.

            // Retrieve the total freight cost for each order and list in descending order.

            // Find customers who have placed orders in every month of the year 1996.

            // Get the names of employees who have not shipped orders to "New York".

            // List all products with a quantity per unit containing the word "Bottle" or "Can".

            // Retrieve the names of suppliers who have a contact name containing "James".

            // Find all orders that were shipped with a freight cost above the average for orders shipped by "Federal Shipping".

            // Get the total number of products in stock for each category and sort in ascending order.

            // List all products that have a unit price higher than the average for their respective categories.

            // Retrieve the names of employees who have shipped orders to customers with a postal code starting with "9".

            // Find suppliers that have provided products with a unit price less than $25 and more than $50.

            // Get all orders that were placed in the month of July and shipped by "United Package".

            // List the top 5 cities with the highest number of shipped orders.

            // Retrieve the names and contact details of suppliers who have provided products in the "Confections" category.

            // Find all products that are currently out of stock but have been ordered in the past year.

            // Get the total number of products supplied by each supplier and list in descending order.

            // List all customers with a contact title of "Sales Representative" and who have ordered more than 3 products.

            // Retrieve the names of employees who have processed orders for the highest number of products.

            // Find the suppliers that have the same contact title as the employee with the most orders.

            // Get all orders that were shipped with a discount applied.

            // List the products with the highest quantity per unit and their respective suppliers.

            // Retrieve the names and addresses of customers who live in cities where the average order amount is above $200.

            // Find all products that have been ordered more than the average quantity ordered per product in the "Condiments" category.

            // Get the details of the orders that were shipped to "Berlin" and have a freight cost above $50.

            // List all categories with at least 10 products and sort by the total quantity of products in stock.

            // Retrieve the names of suppliers who have the highest number of products in the "Dairy Products" category.

            // Find all orders where the order date is within the first quarter of 1996 and the freight cost is less than $30.

            // Get the total sales amount for each employee and list them in descending order.

            // List all products with a unit price greater than the average price in their category and with a reorder level above 10.

            // Retrieve the names of customers who have placed orders in every month of 1997.

            // Find the products that have the highest quantity ordered and were supplied by suppliers from "Italy".

            // Get all orders where the ship city is "Seattle" and the order amount is greater than $100.

            // List all employees who have shipped products with a quantity greater than the average quantity ordered.

            // Retrieve the names of suppliers who have provided products with a unit price between $20 and $40.

            // Find the top 10 products with the highest total quantity ordered.

            // Get all orders where the required date is before the order date and the freight cost is below $25.

            // List the names and contact titles of suppliers who have shipped products in the "Seafood" category.

            // Retrieve the names of employees who have processed orders for more than 5 different categories.

            // Find all products that have been ordered by customers with a postal code starting with "1" and are in stock.

            // Get the total number of orders placed by customers from each city and list them in descending order.

            #endregion Medium

            #region Hard
            // Retrieve the top 5 customers who have the highest total order amount and list their order count.

            // Find the average discount applied to orders for each product category.

            // Get the names of employees who have shipped orders with a freight cost above the median freight cost of all orders.

            // List all products that are supplied by the supplier with the most products and have been ordered more than the average quantity.

            // Retrieve the top 3 categories with the highest average product unit price.

            // Find the customers who have ordered products from every category at least once.

            // Get the details of the order with the longest time between order date and required date.

            // List all suppliers who have not supplied products to any orders in the year 1996.

            // Retrieve the total number of products ordered for each product and compare it to the total stock quantity.

            // Find all products that have a reorder level equal to the maximum reorder level for their category.

            // Get the names of all customers who have ordered products from suppliers with more than 5 products.

            // List the employees who have processed orders for customers in more than 4 different countries.

            // Retrieve the names of categories where the average unit price of products is greater than the overall average unit price.

            // Find the suppliers who have provided products with a quantity per unit description that includes both "Box" and "Pack".

            // Get all orders where the total order amount is greater than the average order amount for the year 1997.

            // List products that have been ordered in every month of 1996 and have a unit price above $20.

            // Retrieve the names of customers who have placed orders in every year from 1995 to 1997.

            // Find all orders with a freight cost greater than the average freight cost of orders shipped by "Federal Shipping" and "United Package".

            // Get the total number of orders placed by customers who live in cities with more than 3 suppliers.

            // List all products that have been ordered by customers from more than 5 different regions.

            // Retrieve the names of employees who have shipped orders with the maximum discount applied.

            // Find the top 10 products that have been ordered the most in the last 6 months.

            // Get the details of orders where the ship country is the same as the supplier's country.

            // List all categories with products that have never been discontinued and have been ordered more than 10 times.

            // Retrieve the average quantity ordered for each product and compare it to the average stock quantity.

            // Find the customers who have ordered products from suppliers in at least 3 different countries.

            // Get all products that have a unit price within the range of the top 5 % most expensive products in their category.

            // List employees who have processed orders for products in every category.

            // Retrieve the total number of products ordered for each category and sort by descending total quantity.

            // Find the orders that have a ship city different from the customer’s city.

            // Get the details of the top 5 most recent orders and the names of the employees who processed them.

            // List all products with a unit price higher than the average unit price for their supplier.

            // Retrieve the names of suppliers who have a contact title of "Owner" and have provided products in the "Beverages" category.

            // Find the top 5 customers with the highest average order value and the number of orders they have placed.

            // Get all products that have been ordered in the last year and have a reorder level greater than the average reorder level.

            // List the employees who have processed orders for customers with a postal code starting with "9" and "8".

            // Retrieve the total order amount for each category and list them in descending order.

            // Find the suppliers who have not supplied products to any customers with orders in 1997.

            // Get the names of customers who have placed orders with products that have a unit price higher than the average unit price of products in their category.

            // List all products that have been ordered by customers from cities with the top 3 highest order counts.

            // Retrieve the names and contact titles of suppliers who have shipped products to "Paris" and "London".

            // Find all orders with a freight cost that is above the median freight cost and was shipped by "Speedy Express".

            // Get the top 5 products with the highest average discount applied and list their total quantity ordered.

            // List all employees who have shipped orders with a total freight cost above the average for the year 1996.

            // Retrieve the total number of products in stock for each category where the average unit price is above $30.

            // Find the customers who have placed orders with a discount applied and have ordered products from at least 4 different suppliers.

            // Get all products that have a unit price greater than the average for their supplier and have been ordered more than 10 times.

            // List all categories with products that have a reorder level equal to the average reorder level of products in their category.

            // Retrieve the names of suppliers who have provided products in the "Seafood" category and have a fax number.

            // Find the top 5 cities with the highest total order amount and list the number of customers in each city.

            // Get the details of orders where the ship name contains "Express" and the freight cost is above $40.

            // List the top 3 most expensive products in each category and retrieve their supplier details.

            // Retrieve the total number of orders placed by customers with a postal code starting with "1" and "2".

            // Find the products that have a quantity per unit description containing "Can" or "Pack" and have been ordered more than the median quantity.

            // Get the names of customers who have placed orders with products that have the highest total quantity ordered.

            // List all orders where the ship city is different from the customer’s city and the order amount is above the average.

            // Retrieve the names of employees who have shipped orders with a total quantity of products ordered above the average.

            // Find the top 10 products with the highest unit price that have been ordered in the last year.

            // Get the details of orders where the ship country is the same as the supplier’s country and the freight cost is above the average.

            // List all products that have been ordered by customers in cities with a total order amount greater than $1000.

            // Retrieve the names of suppliers who have provided products with a unit price less than $20 and more than $50.

            // Find the categories with products that have never been discontinued and have been ordered in every month of the last year.

            // Get the total number of orders for each category where the average order amount is greater than $200.

            // List all customers who have placed orders in every month of the last year and have a postal code starting with "1".

            // Retrieve the names of employees who have processed orders for the highest number of products and their total order amount.

            // Find the suppliers who have the highest number of products in categories where the average unit price is above $30.

            // Get all products that have a unit price higher than the median unit price in their category and have been ordered more than 20 times.

            // List all orders where the freight cost is above the average for the year 1997 and the order date is before the ship date.

            // Retrieve the top 5 customers with the highest average discount applied and their total order amount.

            // Find the products that have been ordered more than the average quantity ordered for their category and have a unit price above $25.

            // Get the names of suppliers who have provided products with a quantity per unit description containing "Bottle" and "Can".

            // List all employees who have shipped orders with a freight cost above the average and have processed orders for customers in more than 3 different countries.

            // Retrieve the total number of products in stock for each category where the reorder level is above the average for products in their category.

            // Find the customers who have placed orders for products in categories where the average quantity ordered is above 50.

            // Get all orders where the ship city is the same as the customer’s city and the order amount is above the median order amount.

            // List all categories with products that have a reorder level less than the average reorder level for their category and have been ordered more than 5 times.

            // Retrieve the names of suppliers who have provided products with a unit price within the range of the top 5 % most expensive products.

            // Find the top 10 cities with the most customers and list the total order amount for each city.

            // Get the details of orders where the ship country is "USA" and the order amount is greater than the average order amount for the year 1996.

            // List all products with a unit price greater than the average unit price in their category and have been ordered in the last 6 months.

            // Retrieve the names of employees who have shipped orders to customers with postal codes starting with "9" and "8" and have processed more than 20 orders.

            // Find the top 5 suppliers with the highest total quantity of products supplied and list their contact details.

            // Get all orders where the total order amount is greater than the average for orders shipped by "Speedy Express" and "United Package".

            // List all products that have been ordered in every year from 1995 to 1997 and have a reorder level higher than the average for their category.

            // Retrieve the names of suppliers who have provided products with a quantity per unit description containing "Pack" and "Box" and have a contact title starting with "Sales".

            // Find the customers who have placed orders with a discount applied and have ordered products from more than 5 different categories.

            // Get the total number of orders placed by customers who have ordered products in every month of the year 1997.

            // List all products with a unit price that is within the range of the average unit price plus one standard deviation for their category.

            // Retrieve the names of employees who have processed orders with the maximum number of products ordered and their total freight cost.

            // Find the top 3 categories with the highest total quantity of products ordered and list their average unit price.

            // Get all orders where the order amount is above the average for orders shipped by "Federal Shipping" and "Speedy Express".

            // List all suppliers who have shipped products to "London" and "Paris" and have provided products in the "Beverages" category.

            // Retrieve the names of customers who have ordered products from suppliers in more than 5 different countries.

            // Find the products that have been ordered more than the median quantity ordered and have a unit price above $30.

            // Get the total order amount for each employee and list them in descending order of the total amount.

            // List all categories with products that have a unit price higher than the median unit price for their category and have been ordered more than 10 times.

            // Retrieve the names of suppliers who have provided products with a quantity per unit description containing "Bottle" or "Pack" and have a fax number.

            // Find the top 5 products with the highest quantity ordered in the last year and their total order amount.

            // Get all orders where the ship country is "USA" and the order date is within the first quarter of 1997.

            // List all products that have a unit price within the range of the top 10 % most expensive products and have been ordered in every month of the last year.


            #endregion Hard
        }
    }
}