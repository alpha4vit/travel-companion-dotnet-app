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
    public Object GetAll(int limit, int page)
    {
        var posts = postRepository.getPage(page, limit);
        Response.Headers.Add("total_count", postRepository.getAllCount().ToString());
        return postMapper.toDTOs(posts);
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
        post.User = user;
        return Ok(postMapper.toDTO(postRepository.save(post)));
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