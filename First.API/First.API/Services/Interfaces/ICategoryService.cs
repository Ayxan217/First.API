using First.API.DTOs.Category;
using System.Linq.Expressions;

namespace First.API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDTO>> GetAllAsync(int page,int take);
        Task<GetCategoryDetailDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCategoryDTO categoryDTO);
        Task UpdateAsync(int id, UpdateCategroryDTO categroryDTO);
        Task DeleteAsync(int id);
    }
}
