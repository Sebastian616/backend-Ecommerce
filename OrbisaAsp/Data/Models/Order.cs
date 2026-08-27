namespace OrbisaApi.Data.Models
{
    public class Order
    {

        public string id { get; set; }
        public StateType state { get; set; }
        public DateTime date { get; set; }
        public User? user { get; set; }
        public List<Product>? products { get; set; }

        public enum StateType
        {
            CART = 1,
            PENDING = 2,
            ON_PROCESS = 3,
            COMPLETED = 4,
            CANCELLED = 5
        }
    }
}
