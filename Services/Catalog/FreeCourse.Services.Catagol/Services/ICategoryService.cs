using FreeCourse.Services.Catagol.Dtos;
using FreeCourse.Services.Catagol.Models;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Catagol.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(Category category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
