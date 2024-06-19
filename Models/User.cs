using Microsoft.EntityFrameworkCore;

namespace ProjectTwo.Models
{
    [Index(nameof(UserName), IsUnique = true)]


    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<PurchaseHistory> PurchaseHistories { get; set; }
    }
}