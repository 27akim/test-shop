using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly ShopOnlineDbContext _db;

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ShopOnlineDbContext dbContext, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _db = dbContext;
        }

        [EnableQuery(PageSize = 15)]
        public IQueryable<Product> Get()
        {
            return _db.Products;
        }

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            var result = _db.Products.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }
    }
}
