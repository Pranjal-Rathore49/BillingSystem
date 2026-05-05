using Microsoft.EntityFrameworkCore;

namespace BillingSystemApp
{
    public class HisabKitab
    {
        public decimal CalculateKrna(string type, decimal kitnaChala, decimal rate)
        {
            decimal result = 0;
            if (type == "Flat")
            {
                result = rate;
            }
            else if (type == "Usage")
            {
                result = kitnaChala * rate;
            }
            else if (type == "Tier")
            {
                if (kitnaChala <= 100)
                {
                    result = kitnaChala * rate;
                }
                else
                {
                    result = (100 * rate) + ((kitnaChala - 100) * (rate - 2));
                }
            }
            return result;
        }

        public decimal DiscountWala(decimal amnt, string discType, decimal value)
        {
            if (discType == "Sale")
            {
                return amnt - ((amnt * value) / 100);
            }
            if (discType == "Coupon")
            {
                return amnt - value;
            }
            return amnt;
        }
    }

    public class MyDatabase : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FinalBillingDB;Trusted_Connection=True;");
        }
    }
}