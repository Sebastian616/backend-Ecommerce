using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using OrbisaApi.Data.Models;

namespace OrbisaApi.Data.Services
{
    public class UserService
    {
        private const string TABLE_NAME = "User";

        private readonly IAmazonDynamoDB _dynamoDb;

        public UserService(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
        }

        public async Task<User> CreateUser(User user)
        {
            var request = new PutItemRequest
            {
                TableName = TABLE_NAME,
                Item = new Dictionary<string, AttributeValue>
                {
                    ["uuid"] =  new AttributeValue { S = Guid.NewGuid().ToString() },
                    ["name"] = new AttributeValue { S = user.name },
                    ["whatsapp"] = new AttributeValue { S = user.whatsapp },
                }
            };
            await _dynamoDb.PutItemAsync(request);
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var request = new ScanRequest
            {
                TableName = TABLE_NAME
            };

            var response = await _dynamoDb.ScanAsync(request);

            var users = new List<User>();

            foreach (var item in response.Items)
            {
                users.Add(new User(
                    item["uuid"].S,
                    item["name"].S,
                    item["whatsapp"].S
                ));
            }

            return users;
        }

        public async Task<User?> GetById(string uuid)
        {
            var request = new GetItemRequest
            {
                TableName = "User",

                Key = new Dictionary<string, AttributeValue>
                {
                    ["uuid"] = new AttributeValue
                    {
                        S = uuid
                    }
                }
            };

            var response = await _dynamoDb.GetItemAsync(request);
            if (response.Item == null || response.Item.Count == 0)
                return null;

            return new User(
                response.Item["uuid"].S,
                response.Item["name"].S,
                response.Item["whatsapp"].S
            );
        }
    }
}
