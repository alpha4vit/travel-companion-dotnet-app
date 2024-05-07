using System.Globalization;
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
            .ForMember(d => d.DateThere, opt => opt.MapFrom(p => p.DateThere.ToUniversalTime()))
            .ForMember(d => d.DateBack, opt => opt.MapFrom(p => p.DateBack.ToUniversalTime()))
            .ForMember(d => d.CreationDate, opt => opt.MapFrom(p => p.CreationDate.ToUniversalTime()))
            .ReverseMap();
        CreateMap<PostResponse, PostResponseDTO>().ReverseMap();
        CreateMap<Address, AddressDTO>()
            .ForMember(a => a.Latitude, opt => opt.MapFrom(a => double.Parse(a.Latitude, NumberStyles.Any, CultureInfo.InvariantCulture)))
            .ForMember(a => a.Longitude, opt => opt.MapFrom(a =>  double.Parse(a.Longitude, NumberStyles.Any, CultureInfo.InvariantCulture)))
            .ReverseMap();
        CreateMap<models.Route, RouteDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Review, ReviewDTO>().ReverseMap();
    }
}