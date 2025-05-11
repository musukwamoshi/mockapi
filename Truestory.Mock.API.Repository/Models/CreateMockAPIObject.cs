using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truestory.Mock.API.Repository.Models
{
    public class CreateMockAPIObject
    {
        public required string Name { get; set; }
        public required object Data { get; set; }
    }
}
