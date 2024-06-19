using System.Data.Common;
using Microsoft.Identity.Client;

namespace ProjectTwo.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<PurchaseHistory> PurchaseHistories { get; set; }
    }
}