using AutoMapper;
using TravelCompanionApp.dto;
using TravelCompanionApp.models;

namespace TravelCompanionApp.mapper;

public class ReviewMapper : BaseMapper<Review, ReviewDTO>
{
    public ReviewMapper(IMapper mapper) : base(mapper)
    {
    }
}