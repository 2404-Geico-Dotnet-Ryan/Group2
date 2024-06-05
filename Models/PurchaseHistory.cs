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
        // No Arg Constructor
        public PurchaseHistory()
        {

        }

        // Full Arg Constructor
        public PurchaseHistory(int purchaseHistoryId, int userId, int plantId, double price, int quantity)
        {
            PurchaseHistoryId = purchaseHistoryId;
            UserId = userId;
            PlantId = plantId;
            Price = price;
            Quantity = quantity;
        }

        // ToString
        public override string ToString()
        {
            return $"{{PurchaseId: {PurchaseHistoryId}, User Id: {UserId}, Plant Id: {PlantId}, Price: {Price}, Quantity: {Quantity}}}";
        }
    }
}