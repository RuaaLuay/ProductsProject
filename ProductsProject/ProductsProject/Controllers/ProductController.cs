using Microsoft.AspNetCore.Mvc;
using ProductsProject.DTOs;
using ProductsProject.Services;

namespace ProductsProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_productService.getAll());
        }
        [HttpGet]
        public IActionResult get(int Id)
        {
            return Ok(_productService.get(Id));
        }
        [HttpPut]
        public IActionResult update(UpdateProductDto dto)
        {
            return View();
        }
        [HttpDelete]
        public IActionResult delete(int Id)
        {
            _productService.delete(Id);
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto dto)
        {
            return Ok(_productService.create(dto));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductDto dto)
        {
            return Ok(_productService.update(dto));
        }
    }
}
