namespace JewlryShop2.Models
{
    public class Cart
    {
        public List <Item> Items { get; set; }
        public int CartId { get; set; }

        public string CustomerName { get; set; } 
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

    }
}

