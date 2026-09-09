using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Extensions
{
    public static class MapToResponseDtoExtensions
    {
        // Converts Product entity into ProductResponseDto
        public static ProductResponseDto MapToResponseDto(this Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category,
                IsActive = product.IsActive,
                CreatedOn = product.CreatedOn
            };
        }
    }
}   