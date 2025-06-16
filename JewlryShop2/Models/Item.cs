namespace JewlryShop2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int JewelryID { get; set; }
        public Jewelry Jewelry { get; set; }
        public Cart Cart { get; set; }
        public int CartID { get; set; }

    }
}
