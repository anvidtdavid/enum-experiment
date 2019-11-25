using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnumExperiment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnumExperiment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly Dictionary<string, Dictionary<string, EnumDescriptor>> enumDescriptors;

        public CommonController(Dictionary<string, Dictionary<string, EnumDescriptor>> enumDescriptors)
        {
            this.enumDescriptors = enumDescriptors;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEnumDescriptors()
        {
            return await Task.FromResult(Ok(enumDescriptors));
        }
    }
}