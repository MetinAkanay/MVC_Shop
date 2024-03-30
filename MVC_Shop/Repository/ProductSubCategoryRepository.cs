using MVC_Shop.DMO;
using MVC_Shop.Models.DTO;

namespace MVC_Shop.Repository
{
    public interface IProductSubCategoryRepository
    {
        public List<ProductSubCategoryDTO> GetAll();
    }
    public class ProductSubCategoryRepository : IProductSubCategoryRepository
    {
        // Tüm alt kategorileri dönen bir metot yapalım

        private AdventureWorks2019Context _context;

        public ProductSubCategoryRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public List<ProductSubCategoryDTO> GetAll()
        {
            var result = _context.ProductSubcategories.Select(s => new ProductSubCategoryDTO
            {
                Id = s.ProductSubcategoryId,
                Name = s.Name
            }).ToList();

            return result;
        }
    }
}
