using System;
using System.Linq;

namespace BillingSystemApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new MyDatabase();
            context.Database.EnsureCreated();

            var calc = new HisabKitab();

            var c1 = new Customer { ClientKaNaam = "Pranjal Rathore" };
            context.Customers.Add(c1);
            context.SaveChanges();

            decimal pehlaAmount = calc.CalculateKrna("Usage", 125, 12);
            decimal finalAmount = calc.DiscountWala(pehlaAmount, "Sale", 5);

            var b = new Bill
            {
                ClientId = c1.Id,
                TotalPaisa = finalAmount,
                BillStatus = Status.Draft
            };
            context.Bills.Add(b);
            context.SaveChanges();

            b.ChangeStatus(Status.Done);
            context.SaveChanges();

            b.ChangeStatus(Status.PaisaMilGya);
            context.SaveChanges();

            Console.WriteLine("Process Completed!");
            Console.WriteLine("Customer: " + c1.ClientKaNaam);
            Console.WriteLine("Final Bill: " + b.TotalPaisa);
            Console.WriteLine("Status: " + b.BillStatus);

            Console.ReadLine();
        }
    }
}