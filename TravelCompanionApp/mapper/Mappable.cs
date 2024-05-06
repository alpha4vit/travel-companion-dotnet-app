namespace TravelCompanionApp.mapper;

public interface Mappable<E, D>
{
    E toEntity(D dto);
    D toDTO(E entity);
    ICollection<E> toEntities(ICollection<D> dtos);
    ICollection<D> toDTOs(ICollection<E> entities);
}