namespace JewlryShop2.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Jewelry> Basket { get; set; }
    }
}
