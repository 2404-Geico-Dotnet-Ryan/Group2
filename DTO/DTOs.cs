namespace ProjectTwo.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class PlantDTO

    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class PurchaseHistoryDTO
    {
        public int PurchaseHistoryId { get; set; }
        public int UserId { get; set; }
        public int PlantId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}