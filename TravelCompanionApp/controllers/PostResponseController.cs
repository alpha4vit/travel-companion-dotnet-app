using Microsoft.AspNetCore.Mvc;
using TravelCompanionApp.dto;
using TravelCompanionApp.mapper;
using TravelCompanionApp.repository;

namespace TravelCompanionApp.controllers;

[ApiController]
[Route("/api/v1/responses")]
public class PostResponseController : ControllerBase
{
    private readonly PostResponseMapper postResponseMapper;
    private readonly PostResponseRepository postResponseRepository;
    private readonly PostRepository postRepository;
    private readonly UserRepository userRepository;

    public PostResponseController(PostResponseMapper postResponseMapper, PostResponseRepository postResponseRepository, PostRepository postRepository, UserRepository userRepository)
    {
        this.postResponseMapper = postResponseMapper;
        this.postResponseRepository = postResponseRepository;
        this.postRepository = postRepository;
        this.userRepository = userRepository;
    }

    [HttpGet("users/{userId:guid}")]
    public async Task<IActionResult> getAllByUser(Guid userId)
    {
        var res = postResponseRepository.getAllByUserId(userId);
        return Ok(postResponseMapper.toDTOs(res));
    }

    [HttpDelete("{responseId:long}")]
    public async Task<IActionResult> deleteById(long responseId)
    {
        postResponseRepository.deleteById(responseId);
        return Ok();
    }

    [HttpPost("users/{userId:guid}/{postId:guid}")]
    public async Task<IActionResult> create(Guid userId, Guid postId, [FromBody] PostResponseDTO postResponseDto)
    {
        var postResponse = postResponseMapper.toEntity(postResponseDto);
        postResponse.PostId = postRepository.getById(postId).Id;
        postResponse.UserId = userRepository.getById(userId).Id;
        var res = postResponseRepository.save(postResponse);
        return Ok(postResponseMapper.toDTO(res));
    }
}