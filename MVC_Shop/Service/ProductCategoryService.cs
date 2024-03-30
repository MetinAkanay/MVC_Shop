using MVC_Shop.Models.DTO;
using MVC_Shop.Repository;

namespace MVC_Shop.Service
{
    public interface IProductCategoryService
    {
        public List<ProductSubCategoryDTO> GetAll();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductSubCategoryRepository _repository;
        public ProductCategoryService(IProductSubCategoryRepository repository)
        {
            _repository = repository;
        }
        public List<ProductSubCategoryDTO> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
