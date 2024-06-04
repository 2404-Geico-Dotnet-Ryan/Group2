using System.Data.Common;
using Microsoft.Identity.Client;

namespace ProjectTwo.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string PlantName { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public int UserId { get; set; }
        public User? Buyer { get; set; }

        // No Arg Constructor
        public Plant()
        {
            PlantName = "";
        }

        // Full Arg Constructor
        public Plant(int id, string plantName, double price, bool available, int userId, User? buyer)
        {
            Id = id;
            PlantName = plantName;
            Price = price;
            Available = available;
            UserId = userId;
            Buyer = buyer;

        }

        public override string ToString()
        {
            return $"{{Id: {Id}, Plant Name: '{PlantName}', Price: {Price}, Available: {Available}, User Id: {UserId}, Buyer: '{Buyer}'}}";
        }

    }
}