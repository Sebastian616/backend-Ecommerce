namespace OrbisaApi.Data.Models
{
    public class OrderDetail
    {
        private string Id {  get; set; }
        private Product Product {  get; set; }
        private User User { get; set; }
        private int Amount { get; set; }
        private string Color { get; set; }
        private string Talla { get; set; }
    }
}
