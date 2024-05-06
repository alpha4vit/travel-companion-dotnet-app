using Microsoft.AspNetCore.Mvc;
using TravelCompanionApp.dto;
using TravelCompanionApp.mapper;
using TravelCompanionApp.repository;

namespace TravelCompanionApp.controllers;

[ApiController]
[Route("/api/v1/reviews")]
public class ReviewController : ControllerBase
{
    private readonly ReviewRepository reviewRepository;
    private readonly ReviewMapper reviewMapper;
    private readonly UserRepository userRepository;

    public ReviewController(ReviewRepository reviewRepository, ReviewMapper reviewMapper)
    {
        this.reviewRepository = reviewRepository;
        this.reviewMapper = reviewMapper;
    }

    [HttpGet("users/{userId:guid}")]
    public async Task<IActionResult> getAllForUser(Guid userId)
    {
        var res = reviewRepository.getAllByUserId(userId);
        return Ok(reviewMapper.toDTOs(res));
    }

    [HttpPost("users/{userId:guid}/{creatorId:guid}")]
    public async Task<IActionResult> create(Guid userId, Guid creatorId, [FromBody] ReviewDTO reviewDto)
    {
        var review = reviewMapper.toEntity(reviewDto);
        review.UserId = userRepository.getById(userId).Id;
        review.CreatorId = userRepository.getById(creatorId).Id;
        var res = reviewRepository.save(review);
        return Ok(reviewMapper.toDTO(res));
    }
}