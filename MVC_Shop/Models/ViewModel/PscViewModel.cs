using MVC_Shop.Models.DTO;

namespace MVC_Shop.Models.ViewModel
{
    public class PscViewModel
    {
        public List<ProductSubCategoryDTO> PSCModel { get; set; }
        public List<ProductDTO> Products { get; set; }
        public int SessionCount { get; set; }
    }
}
