using Microsoft.EntityFrameworkCore;
using TravelCompanionApp.exception;
using TravelCompanionApp.mailsenders;
using TravelCompanionApp.models;

namespace TravelCompanionApp.repository;

public class PostResponseRepository
{
    private readonly ApplicationContext db;
    private readonly MailSender mailSender;

    public PostResponseRepository(ApplicationContext applicationContext, MailSender mailSender)
    {
        this.db = applicationContext;
        this.mailSender = mailSender;
    }

    public PostResponse save(PostResponse postResponse)
    {
        postResponse.CreationDate = DateTime.Now.ToUniversalTime();
        var res = db.Add(postResponse);
        db.SaveChanges();
        Thread th = new Thread(() => mailSender.sendResponseNotification(db.Posts.Find(postResponse.PostId), res.Entity));
        th.Start();
        return res.Entity;
    }

    public List<PostResponse> getAllByUserId(Guid userId)
    {
        return db.PostResponses.ToList().FindAll(post => post.UserId == userId);
    }

    public PostResponse getById(long id)
    {
        var response = db.PostResponses.Find(id);
        if (response == null)
        {
            throw new ResourceNotFoundException("Response with this id not found!");
        }
        return response;
    }

    public void deleteById(long id)
    {
        db.PostResponses.Remove(getById(id));
        db.SaveChanges();
    }
}