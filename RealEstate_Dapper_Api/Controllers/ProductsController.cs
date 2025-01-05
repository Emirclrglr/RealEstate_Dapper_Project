using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithRelations")]
        public async Task<IActionResult> ProductListWithRelations()
        {
            var values = await _productRepository.GetAllProductWithRelationsAsync();
            return Ok(values);
        }

        [HttpGet("GetLast5ProductListings")]
        public async Task<IActionResult> GetLast5ProductListings()
        {
            var value = await _productRepository.GetLast5ProductListing();
            return Ok(value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByIdWithRelations(int id)
        {
            var values = await _productRepository.GetProductByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("GetTrueProductsByEmployeeId/{id}")]
        public async Task<IActionResult> GetTrueProductsByEmployeeId(int id)
        {
            var values = await _productRepository.GetTrueProductsByEmployeeId(id);
            return Ok(values);
        }

        [HttpGet("GetFalseProductsByEmployeeId/{id}")]
        public async Task<IActionResult> GetFalseProductsByEmployeeId(int id)
        {
            var values = await _productRepository.GetFalseProductsByEmployeeId(id);
            return Ok(values);
        }

        [HttpGet("ResultProductByFilter/{keyword}/{categoryId}/{city}")]
        public async Task<IActionResult> ResultProductByFilter(string keyword, int categoryId, string city)
        {
            var values = await _productRepository.ResultProductByFilter(keyword, categoryId, city);
            return Ok(values);
        }

        [HttpGet("GetProductByIsDealOfTheDayTrue")]
        public async Task<IActionResult> GetProductByIsDealOfTheDayTrue()
        {
            var values = await _productRepository.GetProductByIsDealOfTheDayTrue();
            return Ok(values);
        }

        [HttpGet("Last3Listings")]
        public async Task<IActionResult> Last3Listings()
        {
            var values = await _productRepository.Last3Listings();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            _productRepository.CreateProduct(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            _productRepository.UpdateProduct(dto);
            return Ok();
        }

        [HttpPut("SetDealOfTheDayActive/{id}")]
        public IActionResult SetDealOfTheDayActive(int id)
        {
            _productRepository.DealfOfTheDayActive(id);
            return Ok();
        }

        [HttpPut("SetDealOfTheDayPassive/{id}")]
        public IActionResult SetDealOfTheDayPassive(int id)
        {
            _productRepository.DealfOfTheDayPassive(id);
            return Ok();
        }
      
    }
}
