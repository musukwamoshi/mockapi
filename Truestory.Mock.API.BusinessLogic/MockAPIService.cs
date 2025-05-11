using Truestory.Mock.API.BusinessLogic.Interfaces;
using Truestory.Mock.API.Repository.Interfaces;
using Truestory.Mock.API.Repository.Models;

namespace Truestory.Mock.API.BusinessLogic
{
    public class MockAPIService : IMockAPIService
    {
        private readonly IMockAPIRepository _mockAPIRepository;
       
      
        public MockAPIService(IMockAPIRepository mockAPIRepository)
        {
            _mockAPIRepository = mockAPIRepository;
        }

        public async Task<IEnumerable<MockAPIObject>> OnGetMockObjectsByNameAsync(string name,int page,int pageSize)
        {
            var response = await _mockAPIRepository.GetMockObjectsAsync();
            var filtered = response
                .Where(o => o.Name != null && o.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            if (filtered != null)
            {
                return filtered;
            }
            else
            {
                return Enumerable.Empty<MockAPIObject>();
            }
               
        }
        public async Task<MockAPIObjectCreated?> OnAddMockObjectAsync(CreateMockAPIObject newObject)
        {
            var response = await _mockAPIRepository.AddMockObjectAsync(newObject);
            return response;
        }
        public async Task<MockAPIObjectDeleted?> OnDeleteMockObjectsByIdAsync(string id)
        {
            var response = await _mockAPIRepository.DeleteMockObjectsByIdAsync(id);
            return response;
        }

    }
}
