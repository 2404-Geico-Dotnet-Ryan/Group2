using ProjectTwo.Data;
using ProjectTwo.Models;

class EFUserRepo : IUserRepo
{
    private readonly AppDbContext _context;

    public EFUserRepo(AppDbContext context)
    {
        _context = context;
    }

    public User AddUser(User u)
    {
        _context.Users.Add(u);
        return u;
    }

    public User? DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }
        return user;
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User? GetUser(int id)
    {
        return _context.Users.Find(id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public User UpdateUser(User u)
    {
        _context.Users.Update(u);
        return u;
    }
}