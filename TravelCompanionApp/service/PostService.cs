using TravelCompanionApp.models;

namespace TravelCompanionApp.service;

public interface PostService
{
     List<Post> getAll();
     Post getById(Guid id);
     List<Post> getPage(int page, int limit);
     int getAllCount();
     Post save(Post post);
}