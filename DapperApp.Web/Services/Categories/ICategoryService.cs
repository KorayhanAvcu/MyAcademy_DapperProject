using DapperApp.Web.DTOs.Categories;

namespace DapperApp.Web.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllAsync();
        Task<ResultCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto createCategoryDto);
        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteAsync(int id);
    }
}
