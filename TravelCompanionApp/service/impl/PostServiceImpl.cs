using TravelCompanionApp.models;
using TravelCompanionApp.repository;

namespace TravelCompanionApp.service.impl;

public class PostServiceImpl : PostService
{

    private readonly PostRepository postRepository;
    public List<Post> getAll()
    {
        return postRepository.getAll();
    }

    public Post getById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Post> getPage(int page, int limit)
    {
        throw new NotImplementedException();
    }

    public int getAllCount()
    {
        throw new NotImplementedException();
    }

    public Post save(Post post)
    {
        throw new NotImplementedException();
    }
}