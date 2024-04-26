namespace MVC_Shop.Models.DTO
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Photo { get; set; }
        public int StockQuantity { get; set; }
    }
    public class GroupBasket{
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public BasketDTO Product { get; set; }

    }
}
