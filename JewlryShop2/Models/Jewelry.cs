namespace JewlryShop2.Models
{
    public class Jewelry
    {
        public int JewelryID { get; set; }
        public string JewelryName { get; set; }

        public double Price { get; set; }
        public string Material { get; set; }

        public string? ImageName { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public List<Item> Items { get; set; }

    }
}
