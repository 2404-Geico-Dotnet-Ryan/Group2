namespace ProjectTwo.Models
{
    public class PurchaseHistory
    {
        public int PurchaseHistoryId { get; set; }
        public int UserId { get; set; }
        public int PlantId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public User User { get; set; }
        public Plant Plant { get; set; }
    }
}