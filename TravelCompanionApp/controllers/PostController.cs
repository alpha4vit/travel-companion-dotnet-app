using Microsoft.AspNetCore.Mvc;
using TravelCompanionApp.dto;
using TravelCompanionApp.mapper;
using TravelCompanionApp.repository;

namespace TravelCompanionApp.controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostController : ControllerBase
{
    private readonly PostRepository postRepository;
    private readonly UserRepository userRepository;
    private readonly PostMapper postMapper;
    private PostResponseMapper postResponseMapper;
    private PostResponseRepository postResponseRepository;
    
    public PostController(
        PostRepository postRepository, 
        UserRepository userRepository,
        PostMapper postMapper,
        PostResponseMapper postResponseMapper,
        PostResponseRepository postResponseRepository)
    {
        this.postRepository = postRepository;
        this.userRepository = userRepository;
        this.postMapper = postMapper;
        this.postResponseMapper = postResponseMapper;
        this.postResponseRepository = postResponseRepository;
    }
    
    [HttpGet]
    public Object GetPosts()
    {
        return postMapper.toDTOs(postRepository.getAll());
    }
    
    [HttpGet("{id:guid}")]
    public Object GetPostById(Guid id)
    {
        return postMapper.toDTO(postRepository.getById(id));
    }
    
    [HttpGet("pages")]
    public async Task<IActionResult> GetAll(int limit, int page)
    {
        var posts = postRepository.getPage(page, limit);
        var postDtos = postMapper.toDTOs(posts);

        var responseBody = new
        {
            data = new
            {
                body = postDtos,
                headers = new
                {
                    total_count = postRepository.getAllCount().ToString()
                }
            },
            status = 200,
            statusText = "",
            headers = new
            {
                cache_control = "no-cache, no-store, max-age=0, must-revalidate",
                content_type = "application/json",
                expires = "0",
                pragma = "no-cache"
            }
        };

        return Ok(responseBody);
    }
    
    
    [HttpGet("user/{userId:guid}")]
    public Object GetAllByUser(Guid userId)
    {
        var posts = postRepository.getAllByUserId(userId);
        return postMapper.toDTOs(posts);
    }

    [HttpPost("{userId:guid}/create")]
    public async Task<IActionResult> createPost(Guid userId, [FromBody] PostDTO postDto)
    {
        var user = userRepository.getById(userId);
        var post = postMapper.toEntity(postDto);
        post.UserId = user.Id;
        var res = postRepository.save(post);
        res.User = user;
        return Ok(postMapper.toDTO(res));
    }

    [HttpPost("{postId:guid}/respond/{userId:guid}")]
    public async Task<IActionResult> respondPost(Guid postId, Guid userId, [FromBody] PostResponseDTO postResponseDto)
    {
        var postResponse = postResponseMapper.toEntity(postResponseDto);
        postResponse.UserId = userRepository.getById(userId).Id;
        postResponse.PostId  = postRepository.getById(postId).Id;
        var res = postResponseRepository.save(postResponse);
        return Ok(postResponseMapper.toDTO(res));
    }


    [HttpDelete("{postId:guid}")]
    public async Task<IActionResult> deletePost(Guid postId)
    {
        postRepository.deleteById(postId);
        return Ok();
    }

    [HttpPatch("{postId:guid}")]
    public async Task<IActionResult> updatePost(Guid postId, [FromBody] PostDTO postDto)
    {
        var res = postRepository.update(postMapper.toEntity(postDto));
        return Ok(postMapper.toDTO(res));
    }
    
    
}