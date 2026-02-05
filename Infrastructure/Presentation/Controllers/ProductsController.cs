using Microsoft.AspNetCore.Mvc;
using Service;
using ServiceAbstraction;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    // products controller need to use product service
    // but what if we need to use other services too?
    // instead of injecting each service separately 
    // we can inject a service manager that contains all services
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var Products = await serviceManager.ProductService.GetAllProductsAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProductDTO>> GetProduct()
        {

        }
    }
}
