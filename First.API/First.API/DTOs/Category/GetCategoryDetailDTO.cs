using First.API.DTOs.Product;

namespace First.API.DTOs.Category
{
    public record GetCategoryDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetProductDTO> ProductDTOs { get; set; }
    }
}
