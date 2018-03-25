using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repositories
{
    internal class PerformerRepository : BaseRepository<Performer>, IPerformerRepository
    {
        public PerformerRepository(MusicLibraryContext context) : base(context)
        {
        }

        public override IQueryable<Performer> GetAll()
        {
            return base.GetAll().Include(x => x.Albums.Select(album => album.Compositions)).Include(x => x.Albums.Select(album => album.Performer));
        }

        public override bool UpdateEntity(int id, Performer newValue)
        {
            var performer = GetEntity(id);
            if (performer == null)
            {
                return false;
            }
            performer.Albums = newValue.Albums;
            performer.DateOfBirth = newValue.DateOfBirth;
            performer.Name = newValue.Name;
            SaveChanges();
            return true;
        }

        public void RemovePerformerWithChildItems(Performer performer)
        {
            var albums = performer.Albums;
            if (albums != null)
            {
                var compositions = albums.SelectMany(album =>
                    album.Compositions.Where(composition => composition.Albums.All(x => x.Performer == performer)));
                RemoveOtherEntities(compositions);
                RemoveOtherEntities(albums);
            }
            RemoveEntity(performer.Id);
            SaveChanges();
        }
    }
}
