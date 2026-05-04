namespace BillingSystemApp
{
    public class HisabKitab
    {
        public decimal CalculateKrna(string type, decimal kitnaChala, decimal rate)
        {
            decimal result = 0;
            if (type == "Flat")
            {result = rate;
            }
            else if (type == "Usage")
            {result = kitnaChala * rate;
            }
            else if (type == "Tire")
            {
                if (kitnaChala <= 100)
                {result = kitnaChala * rate;
                }
                else
                {result = (100 * rate) + ((kitnaChala - 100) * (rate - 2));
                }
            }
            return result;
        }

        public decimal DiscountWala(decimal amnt, string discType, decimal val)
        {
            if (discType == "Sale")
            {
                decimal discount = (amnt * val) / 100;
                return amnt - discount;
            }
            if (discType == "Coupon")
            {
                return amnt - val;
            }
            return amnt;
        }
    }
}