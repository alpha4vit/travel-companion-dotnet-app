using Microsoft.EntityFrameworkCore;
using TravelCompanionApp.models;

namespace TravelCompanionApp.repository;

public class PostResponseRepository
{
    private readonly ApplicationContext db;

    public PostResponseRepository(ApplicationContext applicationContext)
    {
        this.db = applicationContext;
    }

    public PostResponse save(PostResponse postResponse)
    {
        postResponse.CreationDate = DateTime.Now.ToUniversalTime();
        var res = db.Add(postResponse);
        db.SaveChanges();
        return res.Entity;
    }

    public List<PostResponse> getAllByUserId(Guid userId)
    {
        return db.PostResponses.ToList().FindAll(post => post.UserId == userId);
    }

    public PostResponse getById(long id)
    {
        return db.PostResponses.Find(id);
    }

    public void deleteById(long id)
    {
        db.PostResponses.Remove(getById(id));
        db.SaveChanges();
    }
}