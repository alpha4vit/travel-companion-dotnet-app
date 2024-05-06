using TravelCompanionApp.models;

namespace TravelCompanionApp.repository;

public class ReviewRepository
{
    private readonly ApplicationContext db;
    private readonly UserRepository userRepository;

    public ReviewRepository(ApplicationContext db, UserRepository userRepository)
    {
        this.db = db;
        this.userRepository = userRepository;
    }

    public List<Review> getAllByUserId(Guid userId)
    {
        return db.Reviews.ToList().FindAll(r => r.UserId == userId);
    }

    public Review save(Review review)
    {
        var user = userRepository.getById(review.UserId);
        review.CreationDate = DateTime.Now.ToUniversalTime();
        var res = db.Reviews.Add(review);        
        user.Rating = updateRating(user, review);
        db.SaveChanges();
        return res.Entity;
    }

    private double updateRating(User user, Review review)
    {
        long reviewCount = getAllByUserId(user.Id).Count;
        return (((double)reviewCount*user.Rating+review.Stars)/(reviewCount+1d)).Value;
    }
}