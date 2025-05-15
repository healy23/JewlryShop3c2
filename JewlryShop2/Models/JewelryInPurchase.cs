namespace JewlryShop2.Models
{
    public class JewelryInPurchase
    {
        public int ID { get; set; } 
        public int JewelryID { get; set; }
        public Jewelry Jewelry { get; set; }

        public int PurchaseID { get; set; }
        public Purchase Purchase { get; set; }

        public int Quantity { get; set; }

    }
}
