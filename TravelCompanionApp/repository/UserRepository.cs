using TravelCompanionApp.exception;
using TravelCompanionApp.models;

namespace TravelCompanionApp.repository;

public class UserRepository
{
    private readonly ApplicationContext db;

    public UserRepository(ApplicationContext db)
    {
        this.db = db;
    }

    public List<User> getAll()
    {
        return db.Users.ToList();
    }

    public User getById(Guid id)
    {
        var user = db.Users.Find(id);
        if (user == null)
            throw new ResourceNotFoundException("User with this id not found!"); 
        return user;
    }

    public User update(User user, Guid id)
    {
        var before = getById(id);
        user.Id = before.Id;
        user.Password = before.Password;
        var res = db.Users.Update(user);
        return res.Entity;
    }
}