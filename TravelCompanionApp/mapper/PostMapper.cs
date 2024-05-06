using AutoMapper;
using TravelCompanionApp.dto;
using TravelCompanionApp.models;

namespace TravelCompanionApp.mapper;

public class PostMapper : Mappable<Post, PostDTO>
{
    private readonly IMapper mapper;

    public PostMapper(IMapper mapper)
    {
        this.mapper = mapper;
    }


    public Post toEntity(PostDTO dto)
    {
        return mapper.Map<Post>(dto);
    }

    public PostDTO toDTO(Post entity)
    {
        return mapper.Map<PostDTO>(entity);
    }

    public ICollection<Post> toEntities(ICollection<PostDTO> dtos)
    {
        return mapper.Map<List<Post>>(dtos);
    }

    public ICollection<PostDTO> toDTOs(ICollection<Post> entities)
    {
        return mapper.Map<List<PostDTO>>(entities);
    }
}