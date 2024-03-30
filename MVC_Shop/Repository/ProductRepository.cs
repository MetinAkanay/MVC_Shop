using MVC_Shop.DMO;
using MVC_Shop.Models.DTO;

namespace MVC_Shop.Repository
{
    public interface IProductRepository
    {
        public List<ProductDTO> GetProductBySubCategoryId(int SubCategoryId);
    }
    public class ProductRepository : IProductRepository
    {
        private AdventureWorks2019Context _context;
        
        public ProductRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public List<ProductDTO> GetProductBySubCategoryId(int SubCategoryId)
        {
            var result = _context.Products.Where(s => s.ProductSubcategoryId == SubCategoryId).Select(k => new ProductDTO()
            {
                Id=k.ProductId,
                Name=k.Name,
                Price=k.ListPrice
            }).ToList();

            return result;
        }
    }
}
