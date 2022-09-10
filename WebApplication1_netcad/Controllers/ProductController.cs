using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_netcad;
using App.Business.Services;
using App.Data.Entities;
using System;


namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "productlist")]
        public async Task<IActionResult> Get()
        {
            var list = await _productService.GetProductList();
            return Ok(list);
        }

        //Add Product  
        [HttpPost("AddProduct")]
        public async Task<Object> Add([FromBody] Product product)
        {
            try
            {
                await _productService.Create(product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Delete Product
        [HttpDelete("DeleteProduct")]
        public bool DeletePerson(string title)
        {
            try
            {
                _productService.DeleteProduct(title);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update Product  
        [HttpPut("UpdateProduct")]
        public bool UpdateProduct(Product product)
        {
            try
            {
                _productService.UpdateProduct(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
