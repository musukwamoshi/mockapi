using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Truestory.Mock.API.Repository.Interfaces;
using Truestory.Mock.API.Repository.Models;
namespace Truestory.Mock.API.Repository
{
    public class MockAPIRepository : IMockAPIRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public MockAPIRepository(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }
        public async Task<IEnumerable<MockAPIObject>> GetMockObjectsAsync()
        {
            var client = _httpClientFactory.CreateClient("MockApi");
            var mockObjects = new List<MockAPIObject>();
            var response = await client.GetAsync("objects");
            if (!response.IsSuccessStatusCode)
                return mockObjects;

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("getting all objects");
            Console.WriteLine(json);
            mockObjects = JsonSerializer.Deserialize<List<MockAPIObject>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (mockObjects != null)
            {
                return mockObjects;
            }
            else
            {
                return Enumerable.Empty<MockAPIObject>();
            }

        }
        public async Task<MockAPIObjectCreated?> AddMockObjectAsync([FromBody] CreateMockAPIObject newObject)
        {
            var client = _httpClientFactory.CreateClient("MockApi");

            var json = JsonSerializer.Serialize<CreateMockAPIObject>(newObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("objects", content);

            if (!response.IsSuccessStatusCode)
                return null;
            var result = await response.Content.ReadAsStringAsync();
            var objectCreated = JsonSerializer.Deserialize<MockAPIObjectCreated>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return objectCreated;
        }

        public async  Task<MockAPIObjectDeleted?> DeleteMockObjectsByIdAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("MockApi");

            var response = await client.DeleteAsync($"objects/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorResult = await response.Content.ReadAsStringAsync();

                var objectNotDeleted = JsonSerializer.Deserialize<MockAPIObjectNotDeleted>(errorResult, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var error = new MockAPIObjectDeleted() { Message = objectNotDeleted!.Error };
                return error;

            }

            var result = await response.Content.ReadAsStringAsync();
            var objectDeleted = JsonSerializer.Deserialize<MockAPIObjectDeleted>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return objectDeleted;
        }
      
    }
   
}
