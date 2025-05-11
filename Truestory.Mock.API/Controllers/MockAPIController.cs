using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Truestory.Mock.API.BusinessLogic.Interfaces;
using Truestory.Mock.API.Repository.Models;
using System.Net;

namespace Truestory.Mock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MockAPIController : ControllerBase
    {
        

        private readonly ILogger<MockAPIController> _logger;
        private readonly IMockAPIService _mockAPIService;
        
        public MockAPIController(IMockAPIService mockAPIService,ILogger<MockAPIController> logger)
        {
            _logger = logger;
            _mockAPIService = mockAPIService;
        }


        [HttpGet]
        public async Task<IActionResult> GetObjectsByName([FromQuery] string name="", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _mockAPIService.OnGetMockObjectsByNameAsync(name, page, pageSize);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddObject([FromBody] MockAPIObject newObject)
        {
            if (ModelState.IsValid)
            {
                var response = await _mockAPIService.OnAddMockObjectAsync(newObject);
                return Ok(response);

            }
            else
            {
                return  BadRequest("Invalid Model");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObject(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest("Id cannot be null or empty");
            }
            var response = await _mockAPIService.OnDeleteMockObjectsByIdAsync(id);
            return Ok(response);
        }


    }
}
