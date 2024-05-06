using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelCompanionApp.dto;
using TravelCompanionApp.mapper;
using TravelCompanionApp.repository;

namespace TravelCompanionApp.controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{

    private readonly UserRepository userRepository ;
    private readonly UserMapper userMapper;

    public UserController(UserRepository userRepository, UserMapper userMapper)
    {
        this.userRepository = userRepository;
        this.userMapper = userMapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = userRepository.getAll();
        return Ok(userMapper.toDTOs(users));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = userRepository.getById(id);
        return Ok(userMapper.toDTO(user));
    }

    [HttpPatch("{userId:guid}")]
    public async Task<IActionResult> update(Guid userId, [FromBody] UserDTO userDto)
    {
        userDto.Id = userId;
        var user = userMapper.toEntity(userDto);
        var saved = userRepository.update(user, userId);
        return Ok(userMapper.toDTO(saved));
    }
    
}