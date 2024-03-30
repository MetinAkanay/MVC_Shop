using MVC_Shop.Models.DTO;
using MVC_Shop.Repository;

namespace MVC_Shop.Service
{
    public interface IProductService
    {
        public List<ProductDTO> GetProductBySubCategoryId(int subCategoryId);
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductDTO> GetProductBySubCategoryId(int subCategoryId)
        {
            return _productRepository.GetProductBySubCategoryId(subCategoryId);
        }
    }
}
