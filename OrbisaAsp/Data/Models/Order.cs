namespace OrbisaApi.Data.Models
{
    public class Order
    {

        public string id { get; set; }
        public int state { get; set; }
        public DateTime date { get; set; }
        public User? user { get; set; }
        public List<Product>? products { get; set; }
    }
}
