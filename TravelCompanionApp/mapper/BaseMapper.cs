using AutoMapper;

namespace TravelCompanionApp.mapper;

public class BaseMapper<E, D> : Mappable<E, D>
{

    private readonly IMapper mapper;

    public BaseMapper(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public E toEntity(D dto)
    {
        return mapper.Map<E>(dto);
    }

    public D toDTO(E entity)
    {
        return mapper.Map<D>(entity);
    }

    public ICollection<E> toEntities(ICollection<D> dtos)
    {
        return mapper.Map<List<E>>(dtos);
    }

    public ICollection<D> toDTOs(ICollection<E> entities)
    {
        return mapper.Map<List<D>>(entities);
    }
}