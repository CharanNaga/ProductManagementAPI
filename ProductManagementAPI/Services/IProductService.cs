using ProductManagementAPI.DTOs;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {

        // Returns all products as response DTOs
        Task<List<ProductResponseDto>> GetAllProductsAsync();

        // Returns a single product as response DTO based on the given Id
        Task<ProductResponseDto?> GetProductByIdAsync(Guid id);

        // Creates a new product using the incoming create DTO
        Task<ProductResponseDto> CreateProductAsync(ProductCreateDto dto);

        // Updates an existing product based on the update DTO
        Task<bool> UpdateProductAsync(ProductUpdateDto dto);

        // Deletes an existing product based on the given Id
        Task<bool> DeleteProductAsync(Guid id);
    }
}
