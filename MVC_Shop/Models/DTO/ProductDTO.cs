namespace MVC_Shop.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public byte[] Photo { get; set; }
        public int StockSafetylevel { get; set; }
        public int Quantity { get; set; }

    }
}
