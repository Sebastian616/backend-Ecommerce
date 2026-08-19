using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
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

        public async Task CreateUser(User user)
        {
            var request = new PutItemRequest
            {
                TableName = "Prueba",
                Item = new Dictionary<string, AttributeValue>
                {
                    ["uuid"] = new AttributeValue { S = user.GetUuid() },
                    ["Name"] = new AttributeValue { S = user.GetName() },
                    ["whatsapp"] = new AttributeValue { S = user.GetWhatsapp() }
                    //["cart"] = new AttributeValue { S = user.GetCart() },
                }
            };

            await _dynamoDb.PutItemAsync(request);
        }
    }
}
