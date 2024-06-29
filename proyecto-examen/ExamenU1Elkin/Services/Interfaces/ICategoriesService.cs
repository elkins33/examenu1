using ExamenU1Elkin.Dtos.Categories;

namespace ExamenU1Elkin.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> GetCategoriesListAsync();
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<bool> CreateAsync(CategoryCreateDto dto);
        Task<bool> ReadAsync(CategoryCreateDto dto);
        Task<bool> EditAsync(CategoryEditDto dto);
        Task<bool> DeleteAsync(Guid id);

    }
}
