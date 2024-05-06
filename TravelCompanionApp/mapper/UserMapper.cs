using AutoMapper;
using TravelCompanionApp.dto;
using TravelCompanionApp.models;

namespace TravelCompanionApp.mapper;

public class UserMapper : BaseMapper<User, UserDTO>
{
    public UserMapper(IMapper mapper) : base(mapper)
    {
    }
}