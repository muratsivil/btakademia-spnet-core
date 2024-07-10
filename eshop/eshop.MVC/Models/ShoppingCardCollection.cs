using eshop.Application.DataTransferObjects.Responses;

namespace eshop.MVC.Models
{
    public class ShoppingCardItem
    {
        public ProductCardResponse Product { get; set; }
        public int Quantity { get; set; }
    }
    public class ShoppingCardCollection
    {
        public List<ShoppingCardItem> ShoppingCardItems { get; set; } = new List<ShoppingCardItem>();

        public void Add(ShoppingCardItem item)
        {
            var productExsits = ShoppingCardItems.Find(s => s.Product.Id == item.Product.Id);
            if (productExsits == null)
            {
                ShoppingCardItems.Add(item);
            }
            else
            {
                productExsits.Quantity += item.Quantity;
            }
        }

        public void Clear() => ShoppingCardItems.Clear();

        public decimal GetTotalPrice() => ShoppingCardItems.Sum(p => p.Product.Price * p.Quantity);

        public int GetTotalQuantity() => ShoppingCardItems.Sum(p => p.Quantity);
    }
}
