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
        public ICollection<Plant> Plants { get; set; }

        //No Arg Constructor
        public User()
        {
            UserName = "";
            Password = "";
            FirstName = "";
            LastName = "";
            Role = "";
            Plants = [];
        }

        // Full Arg Constructor
        public User(int userId, string userName, string password, string firstName, string lastName, string role, ICollection<Plant> plants)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Plants = plants;
        }

        // ToString
        public override string ToString()
        {
            return $"{{UserId: {UserId},UserName: '{UserName}',Password: '{Password}',FirstName: '{FirstName}', LastName: '{LastName}', Role: '{Role}'}}";
        }

    }
}