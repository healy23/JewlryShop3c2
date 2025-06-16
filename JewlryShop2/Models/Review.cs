namespace JewlryShop2.Models
{
    public class Review
    {
        public int ID { get; set; }

        public int JewelryID { get; set; }
        public Jewelry Jewelry { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int StarAmount { get; set; }
        public string Rewiew { get; set; }

    }
}
