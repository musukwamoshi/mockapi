using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truestory.Mock.API.Repository.Models;

namespace Truestory.Mock.API.Repository.Interfaces
{
    public interface IMockAPIRepository
    {
        Task<IEnumerable<MockAPIObject>> GetMockObjectsAsync();
        Task<MockAPIObjectCreated?> AddMockObjectAsync(CreateMockAPIObject newObject);
        Task<MockAPIObjectDeleted?> DeleteMockObjectsByIdAsync(string id);
    }
}
