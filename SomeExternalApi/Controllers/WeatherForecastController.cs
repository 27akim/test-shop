using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SomeExternalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDistributedCache cache;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDistributedCache distributedCache)
        {
            cache = distributedCache;
            _logger = logger;
        }

        [HttpGet]
        public Product Get(int id)
        {
            Product? product = null;

            var cacheProduct = cache.GetString(id.ToString());
            product = JsonSerializer.Deserialize<Product>(cacheProduct);

            return product;
        }
    }
}
