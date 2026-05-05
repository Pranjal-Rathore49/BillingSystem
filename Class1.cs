namespace BillingSystemApp
{
    public class Customer
    {
        public int Id { get; set; }
        public string ClientKaNaam { get; set; }
    }

    public enum Status { Draft, Done, PaisaMilGya }

    public class Bill
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal TotalPaisa { get; set; }
        public Status BillStatus { get; set; } = Status.Draft;

        public void ChangeStatus(Status nayaStatus)
        {
            if (BillStatus == Status.Draft && nayaStatus == Status.Done)
            {
                BillStatus = Status.Done;
            }
            if (BillStatus == Status.Done && nayaStatus == Status.PaisaMilGya)
            {
                BillStatus = Status.PaisaMilGya;
            }
        }
    }
}