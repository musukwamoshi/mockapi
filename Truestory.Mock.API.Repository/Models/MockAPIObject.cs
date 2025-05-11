using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truestory.Mock.API.Repository.Models
{
    public class MockAPIObject
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public object? Data { get; set; }
    }
}
