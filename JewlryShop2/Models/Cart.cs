namespace JewlryShop2.Models
{
    public class Cart
    {
        //public int Id { get; set; }
        public List <Item> Items { get; set; }
        public int CartId { get; set; }

        public string CustomerName { get; set; } // בעקבות הוספת הקישור ליישות לקוח, לא נשתמש בשדה זה
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }


    }
}