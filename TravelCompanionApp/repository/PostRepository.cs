
using Microsoft.EntityFrameworkCore;
using TravelCompanionApp.exception;
using Post = TravelCompanionApp.models.Post;

namespace TravelCompanionApp.repository;

public class PostRepository {
    private readonly ApplicationContext db;

    public PostRepository(ApplicationContext db)
    {
        this.db = db;
    }

    public List<Post> getAll()
    {
        return db.Posts.ToList();
    }

    public Post getById(Guid id)
    {
        var post = db.Posts.Find(id);
        if (post == null)
            throw new ResourceNotFoundException("Post with this id not found!");
        return post;
    }
    
    public List<Post> getPage(int page, int limit)
    {
        int skip = (page - 1) * limit;
        return db.Posts.Skip(skip).Take(limit).ToList();
    }
    
    public long getAllCount()
    {
        return db.Posts.ToList().Count;
    }

    public Post save(Post post)
    {
        post.CreationDate = DateTime.Now.ToUniversalTime();
        var res = db.Add(post);
        db.SaveChanges();
        return res.Entity;
    }

    public void deleteById(Guid postId)
    {
        db.Posts.Remove(getById(postId));
        db.SaveChanges();
    }

    public Post update(Post post)
    {
        var res = db.Posts.Update(post);
        db.SaveChanges();
        return res.Entity;
    }

    public List<Post> getAllByUserId(Guid userId)
    {
        return db.Posts.ToList().FindAll(p => p.UserId == userId);
    }
}