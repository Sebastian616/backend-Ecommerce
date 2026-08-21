namespace OrbisaApi.Data.Models
{
    public class User
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string whatsapp { get; set; }
        public List<OrderDetail> cart { get; set; }

        public User(string uuid, string name, string whatsapp, List<OrderDetail> cart = null)
        {
            this.uuid = uuid;
            this.name = name;
            this.whatsapp = whatsapp;
            this.cart = new List<OrderDetail>();
        }
        //Getters
        //Setters
    }
}
