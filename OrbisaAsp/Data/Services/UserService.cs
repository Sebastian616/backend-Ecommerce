using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using OrbisaApi.Data.Models;

namespace OrbisaApi.Data.Services
{
    public class UserService
    {
        private readonly IAmazonDynamoDB _dynamoDb;

        public UserService(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
        }

        public async Task<User> CreateUser(User user)
        {
            var request = new PutItemRequest
            {
                TableName = "Prueba",
                Item = new Dictionary<string, AttributeValue>
                {
                    ["mondongo"] =  new AttributeValue { S = "1" },
                    ["uuid"] = new AttributeValue { S = user.uuid },
                    ["name"] = new AttributeValue { S = user.name },
                    ["whatsapp"] = new AttributeValue { S = user.whatsapp }
                    //["cart"] = new AttributeValue { S = user.GetCart() },
                }
            };
            await _dynamoDb.PutItemAsync(request);
            return user;
        }
        /*
        public async Task<IActionResult> Index()
        {
            var request = new ScanRequest
            {
                TableName = "Prueba"
            };

            var response = await _dynamoDb.ScanAsync(request);

            var videos = response.Items.Select(item => new User
            {
                uuid = item["video_id"].N,
                name = item["titulo"].S,
                whatsapp = item["url"].S,
                cart = null
            }).ToList();

            return View(videos);
        }*/
    }
}
