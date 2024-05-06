using AutoMapper;
using TravelCompanionApp.dto;
using TravelCompanionApp.models;

namespace TravelCompanionApp.mapper;

public class PostResponseMapper : Mappable<PostResponse, PostResponseDTO>
{
    private readonly IMapper mapper;

    public PostResponseMapper(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public PostResponse toEntity(PostResponseDTO dto)
    {
        return mapper.Map<PostResponse>(dto);
    }

    public PostResponseDTO toDTO(PostResponse entity)
    {
        return mapper.Map<PostResponseDTO>(entity);
    }

    public ICollection<PostResponse> toEntities(ICollection<PostResponseDTO> dtos)
    {
        return mapper.Map<List<PostResponse>>(dtos);
    }

    public ICollection<PostResponseDTO> toDTOs(ICollection<PostResponse> entities)
    {
        return mapper.Map<List<PostResponseDTO>>(entities);
    }
}