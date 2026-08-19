namespace OrbisaApi.Data.Models
{
    public class User
    {
        private string uuid { get; set; }
        private string name { get; set; }
        private string whatsapp { get; set; }
        private List<OrderDetail> cart { get; set; }

        public User(string uuid, string name, string whatsapp, List<OrderDetail> cart)
        {
            this.uuid = uuid;
            this.name = name;
            this.whatsapp = whatsapp;
            this.cart = new List<OrderDetail>();
        }
        //Getters
        public string GetUuid(){return uuid; }
        public string GetName() { return name; }
        public string GetWhatsapp() { return whatsapp; }
        public List<OrderDetail> GetCart() { return cart; }
        //Setters

        public void SetUuid(string uuid) { this.uuid = uuid; }
        public void SetName(string name) { this.uuid = name; }
        public void SetWhatsapp(string whatsapp) { this.uuid = whatsapp; }
        public void SetCart(string cart) { this.uuid = cart; }
    }
}
