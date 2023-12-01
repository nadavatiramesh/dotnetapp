using e_commerce.API.Entities;
using e_commerce.API.Models;
using e_commerce.API.Services;
using e_commerce.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService service)
        {
            _productService = service;
        }
       
        [HttpPost("/api/upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpGet("/api/Search")]
        public IActionResult SearchProduct(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest(new { message = "please enter product name to search" });
            }
            var products = new List<ProductModel>();
            var productList = _productService.GetAll();
            var result = productList.Where(x => x.Name.Contains(name,StringComparison.OrdinalIgnoreCase)).ToList();
            if (result != null)
            {
                result.ForEach(e =>
                {
                    products.Add(new ProductModel()
                    {
                        ActualCost = e.ActualCost,
                        Category = e.Category,
                        Color = e.Color,
                        Description = e.Description,
                        ImageLink = e.ImageLink,
                        Name = e.Name,
                        Price = e.Price,
                        ProductId = e.ProductId
                    });
                });
            }
            return Ok(products);
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            var products = new List<ProductModel>();
            var productList = _productService.GetAll();
            if (productList != null)
            {
                productList.ForEach(e =>
                {
                    products.Add(new ProductModel()
                    {
                        ActualCost = e.ActualCost,
                        Category = e.Category,
                        Color = e.Color,
                        Description = e.Description,
                        ImageLink = e.ImageLink,
                        Name = e.Name,
                        Price = e.Price,
                        ProductId = e.ProductId
                    });
                });
            }
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id = 0)
        {
            if(id == 0)
            {
                return BadRequest(new { message = "Product Id required for get Product" });
            }
            var e = _productService.GetProductById(id);
            if (e != null)
            {
                return Ok(new ProductModel()
                {
                    ActualCost = e.ActualCost,
                    Category = e.Category,
                    Color = e.Color,
                    Description = e.Description,
                    ImageLink = e.ImageLink,
                    Name = e.Name,
                    Price = e.Price,
                    ProductId = e.ProductId
                });
            }
            return BadRequest("Invalid Product id");
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel model)
        {
            if (model != null)
            {
                if(string.IsNullOrEmpty(model.Name))
                {
                    return BadRequest(new { message = "Product Name is required" });
                }
                if (string.IsNullOrEmpty(model.Category))
                {
                    return BadRequest(new { message = "Product Category is required" });
                }

                var product = new Product()
                {
                    ActualCost = model.ActualCost,
                    Category = model.Category,
                    Color = model.Color,
                    CreatedBy = "me",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "me",
                    UpdatedOn = DateTime.Now,
                    Description = model.Description,
                    ImageLink = model.ImageLink,
                    Name = model.Name,
                    Price = model.Price
                };
                _productService.AddProduct(product);
                return Created("product", product);
            }
            return BadRequest();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductModel value)
        {
            if(id == 0)
            {
                return BadRequest(new { message = "Product ID is required" });
            }
            if (value != null)
            {
                var product = new Product()
                {
                    ProductId = id,
                    ActualCost = value.ActualCost,
                    Category = value.Category,
                    Color = value.Color,
                    Description = value.Description,
                    Name = value.Name,
                    ImageLink = value.ImageLink,
                    Price = value.Price,
                    UpdatedBy = "me",
                    UpdatedOn = DateTime.Now
                };
               return Ok(_productService.UpdateProduct(id, product));
            }
            return BadRequest();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest(new { message = "Product ID is required" });
            }
            return Ok(_productService.DeleteProduct(id));
        }
    }
}


