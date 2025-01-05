using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ResultProductDto>> GetAllProductAsync();
        Task<IEnumerable<ResultProductWithRelationsDto>> GetAllProductWithRelationsAsync();
        Task<IEnumerable<ResultProductWithRelationsDto>> GetLast5ProductListing();
        Task<IEnumerable<ResultProductWithRelationsDto>> GetTrueProductsByEmployeeId(int id);
        Task<IEnumerable<ResultProductWithRelationsDto>> GetFalseProductsByEmployeeId(int id);
        Task<IEnumerable<ResultProductWithRelationsDto>> GetProductByIsDealOfTheDayTrue();
        Task<IEnumerable<ResultProductWithRelationsDto>> Last3Listings();
        void CreateProduct(CreateProductDto dto);
        void UpdateProduct(UpdateProductDto dto);
        void DeleteProduct(int id);
        Task<ResultProductWithRelationsDto> GetProductByIdAsync(int id);
        void DealfOfTheDayActive(int id);
        void DealfOfTheDayPassive(int id);
        Task<ResultGetProductDetailByIdDto> GetProductDetailByProductId(int id);
        Task<IEnumerable<ResultProductWithRelationsDto>> ResultProductByFilter(string keyword, int propertyCategoryId, string city);
    }
}
