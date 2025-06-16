namespace JewlryShop2.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Gmail { get; set; }

        public string ClubMembership { get; set; }

        public string Password { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
