using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truestory.Mock.API.Repository.Models;

namespace Truestory.Mock.API.BusinessLogic.Interfaces
{
    public interface IMockAPIService
    {
        Task<IEnumerable<MockAPIObject>> OnGetMockObjectsByNameAsync(string name, int page,int pageSize);
        Task<MockAPIObjectCreated?> OnAddMockObjectAsync(MockAPIObject newObject);
        Task<MockAPIObjectDeleted?> OnDeleteMockObjectsByIdAsync(string id);
    }
}
