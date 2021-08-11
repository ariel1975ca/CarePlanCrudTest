using CarePlanWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarePlanWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarePlanController : ControllerBase
    {
        private readonly ILogger<CarePlanController> _logger;

        public CarePlanController(ILogger<CarePlanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ApiCarePlan> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ApiCarePlan
            {
                
            })
            .ToArray();
        }
    }
}
