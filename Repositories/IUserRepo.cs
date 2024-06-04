using ProjectTwo.Models;

interface IUserRepo
{
    public User? AddUser(User u);
    public User? GetUser(int id);
    public List<User>? GetAllUsers();
    public User? UpdateUser(User u);
    public User? DeleteUser(int id);
    public void Save();
}