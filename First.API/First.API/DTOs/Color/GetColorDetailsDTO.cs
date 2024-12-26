using First.API.DTOs.Product;

namespace First.API.DTOs.Color
{
    public record GetColorDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
