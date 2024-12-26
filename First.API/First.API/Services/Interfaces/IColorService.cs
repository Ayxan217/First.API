using First.API.DTOs.Category;
using First.API.DTOs.Color;

namespace First.API.Services.Interfaces
{
    public interface IColorService
    {
        Task<IEnumerable<GetColorDTO>> GetAllAsync(int page, int take);
        Task<GetColorDetailsDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateColorDTO colorDTO);
        Task UpdateAsync(int id, UpdateColorDTO colorDTO);
        Task DeleteAsync(int id);
    }
}
