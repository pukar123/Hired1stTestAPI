using HiredFirst.Domain.DTO;
using HiredFirst.Domain.Services;
using HiredFirst.Domain.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;

namespace HiredFirststTest.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpGet]
        [Route("allProduct")]
        public ActionResult AllProduct()
        {
            var userId = GetCurrentUserId();
            
            var productData=_productService.GetProductListByUserId(userId);
            return Ok(new { result = productData });
        }
        private string GetCurrentUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userId = httpContext?.User?.Claims.FirstOrDefault(a => a.Type == "UserId")?.Value;
            if (userId == null)
            {
                userId = "";
            }
            return userId;
        }
        
        [HttpPut]
        [Route("updateProduct")]
        public IActionResult UpdateProduct([FromBody] ProductDTO request)
        {
            try
            {
                _productService.UpdateProduct(request);
                return Ok(new { message = "Product updated sucessfully" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Authorize]
        [HttpPost]
        [Route("addNew")]
        public IActionResult AddProduct([FromBody] ProductDTO request)
        {
            try
            {
                var userId = GetCurrentUserId();
                request.UserId= userId;
                _productService.InsertProduct(request);
                return Ok(new { message = "Product Inserted sucessfully" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("deleteProduct")]
        public IActionResult DeleteProduct(string request)
        {
            try
            {
                _productService.DeleteProduct(request);
                return Ok(new { message = "Product deleted sucessfully" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
