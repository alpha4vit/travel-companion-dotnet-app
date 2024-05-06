using AutoMapper;
using TravelCompanionApp.dto;
using TravelCompanionApp.models;

namespace TravelCompanionApp.mapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Post, PostDTO>()
            .ForMember(d => d.ResponsesCount, opt => opt.MapFrom(e => e.Responses.Count))
            .ReverseMap();
        CreateMap<PostResponse, PostResponseDTO>().ReverseMap();
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<models.Route, RouteDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Review, ReviewDTO>().ReverseMap();
    }
}