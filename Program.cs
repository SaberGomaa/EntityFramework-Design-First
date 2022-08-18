using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Design First ...
            tradingEntities context = new tradingEntities(); // context cacheing date from datebase to memory
            #region EF in Action
            //context.Database.Log = log => Debug.WriteLine(log);

            //foreach(var customer in context.Customers)
            //{
            //    Console.WriteLine($"ID : {customer.Id} \t{customer.FirstName} {customer.LastName} ");
            //}

            //where processed in server side // defferd Execution
            //var query = context.Customers.Where(c => c.Id > 50);// Filter and and bring result to memory .. //IQuerable


            //where processed in client side // eager Execution
            // var query = context.Customers.ToList().Where(c => c.Id > 50 && c.Id < 60);// bring all in memory and Filter it ...// IEnumerable

            //Exception from Database because int parse do it outer to solve 
            //var query =
            //    from customer in context.Customers
            //    where customer.Id > int.Parse("10") 
            //    select customer;


            //int id = int.Parse("80");
            //var query = context.Customers.Where(c => c.Id > id).Take(5);

            //var query =
            //    (from customer in context.Customers
            //    where customer.Id > 10 && customer.Id < 15
            //    select new { Name = customer.FirstName, Id = customer.Id }).OrderBy(c => c.Id);

            //var query = context.Products.Find(5);

            //foreach (var c in query.OrderItems)
            //{
            //    Console.WriteLine($"{c.OrderId} {c.Order.Id} {c.UnitPrice} ");
            //}

            #endregion

            #region Update

            //var q = context.Customers.First();
            //Console.WriteLine($"ID = {q.Id} name {q.FirstName+" "+q.LastName}");

            //q.FirstName = "saber";
            //q.LastName = "gomaa";

            // Don't Play in Entry State 
            //context.Entry(q).State = System.Data.Entity.EntityState.Detached ;
            //to attach it again
            //context.Customers.Attach(q);

            //var query = 
            //    (from customer in context.Customers
            //    where customer.Id >= 30 
            //    select customer).AsNoTracking();// the returned data is only for read and any update will be only in memory Like Detached

            //context.SaveChanges(); 
            #endregion

            #region difference between single and find ...
            //var C = context.Customers.Find(3); //find search on the cache memory First  // fast if object in cache 
            //var C1 = context.Customers.Single(c => c.Id == 10);// search on datebase directly .. fast if object isnot in cache 
            #endregion

            #region insert parent\child 


            //var q = 
            //    new Customer 
            //    {
            //        FirstName = "maher", 
            //        LastName = "gomaa",
            //        City = "Egypt",
            //        Country = "eg",
            //        Phone = "56565"
            //    };
            //context.Customers.Add(q);

            //context.SaveChanges();

            //try
            //{
            //    var C1 = context.Customers.Single(c => c.Id == 94);// bring it from datebase directly .. fast if object isnot in cache 

            //    Console.WriteLine(C1.FirstName);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("Dont Find it ...");
            //}




            //var cus = new Customer 
            //{ 
            //    FirstName = "saber", 
            //    LastName = "maher" ,
            //};

            //cus.Orders = new List<Order>
            //{
            //    new Order {OrderDate = DateTime.Today},
            //    new Order {OrderDate = DateTime.Today}

            //};
            //context.Customers.Add(cus);

            //var cus = new Customer
            //{
            //    FirstName = "saber ",
            //    LastName = "Elsayed",
            //};

            //var order = new Order
            //{ 
            //    OrderDate = DateTime.UtcNow,
            //    CustomerId = cus.Id,
            //    Customer =cus
            //};

            //context.Orders.Add(order);
            //context.SaveChanges();

            #endregion

            #region Delete from database 
            //var query = context.Customers.Last();
            //context.Customers.Remove(query);

            //context.SaveChanges(); 
            #endregion

            #region Handel DbUpdateConcurrencyException
            //tradingEntities context1 = new tradingEntities();
            //var q1 = context.Products.First();
            //var q2 = context1.Products.First();

            //q1.UnitPrice -= 20;
            //context.SaveChanges();


            //q2.UnitPrice -= 40;
            //try {
            //    context1.SaveChanges();
            //}catch(DbUpdateConcurrencyException e)
            //{
            //    var q3 = e.Entries.First().Entity as Product;

            //    context1.Entry(q3).Reload();
            //    q3.UnitPrice -= 30;
            //    context1.SaveChanges();
            //} 
            #endregion

        }

    }
}
