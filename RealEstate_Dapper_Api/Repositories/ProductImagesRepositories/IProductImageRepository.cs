using RealEstate_Dapper_Api.Dtos.ProductImagesDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImagesRepositories
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<GetProductImageByProductIdDto>> GetProductImageByProductId(int id);
    }
}
