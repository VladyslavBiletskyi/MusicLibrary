using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
        void RemoveAlbumWithCompositions(Album entity);
    }
}
