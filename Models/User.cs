namespace ProjectTwo.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        // public int PurchaseId { get; set; }
        public PurchaseHistory PurchaseHistory { get; set; }

        //No Arg Constructor
        public User()
        {
            UserName = "";
            Password = "";
            FirstName = "";
            LastName = "";
            Role = "";
        }

        // Full Arg Constructor
        public User(int userId, string userName, string password, string firstName, string lastName, string role)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        // ToString
        public override string ToString()
        {
            return $"{{UserId: {UserId},UserName: '{UserName}',Password: '{Password}',FirstName: '{FirstName}', LastName: '{LastName}', Role: '{Role}'}}";
        }

    }
}