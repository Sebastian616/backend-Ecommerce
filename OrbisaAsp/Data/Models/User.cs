using Amazon.DynamoDBv2.DataModel;
namespace OrbisaAsp.Data.Models
{

    [DynamoDBTable("User")]
    public class User
    {
        [DynamoDBHashKey]
        public string uuid { get; set; }
        public string name { get; set; }
        public string whatsapp { get; set; }

        public User(string uuid, string name, string whatsapp)
        {
            this.uuid = uuid;
            this.name = name;
            this.whatsapp = whatsapp;
        }
    }
}
