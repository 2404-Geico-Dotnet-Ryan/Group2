using System.Data.Common;
using Microsoft.Identity.Client;

namespace ProjectTwo.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public double Price { get; set; }
        public int Quantity {get; set; }
        // public bool Available { get; set; }
        // public int UserId { get; set; }
        // public User? Buyer { get; set; }
        public PurchaseHistory PurchaseHistory { get; set; }
        // No Arg Constructor
        public Plant()
        {
            PlantName = "";
        }

        // Full Arg Constructor
        public Plant(int plantId, string plantName, double price, int quantity)
        {
            PlantId = plantId;
            PlantName = plantName;
            Price = price;
            Quantity = quantity;

        }

        public override string ToString()
        {
            return $"{{Plant Id: {PlantId}, Plant Name: '{PlantName}', Price: {Price}, Quantity: {Quantity}}}";
        }

    }
}