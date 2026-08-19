namespace OrbisaApi.Data.Models
{
    public class Order
    {
        private List<OrderDetail> OrderDetail { get; set; }
        private User user {  get; set; }
        private int Stare { get; set; }
        private DateTime Date { get; set; }
    }
}
