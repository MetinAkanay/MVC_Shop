using Microsoft.EntityFrameworkCore;
using MVC_Shop.DMO;
using MVC_Shop.Models.DTO;

namespace MVC_Shop.Repository
{
    public interface IBasketRepository
    {
        public List<BasketDTO> GetProductById(List<int> ids);

    }
    public class BasketRepository : IBasketRepository
    {
        private AdventureWorks2019Context _context;
        public BasketRepository(AdventureWorks2019Context context)
        {

            _context = context;

        }

        public List<BasketDTO> GetProductById(List<int> ids)
        {
            var result = _context.Products.Include(m => m.ProductProductPhotos).ThenInclude(k => k.ProductPhoto).Where(s => ids.Contains(s.ProductId)).Select(k => new BasketDTO()
            {
                Id = k.ProductId,
                Name = k.Name,
                Price = k.ListPrice,
                Photo = k.ProductProductPhotos.Where(s => s.ProductId == s.ProductId).Select(k => k.ProductPhoto.LargePhoto).SingleOrDefault()
            }).ToList();

            return result;
        }
    }
}
