using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repositories
{
    internal class CompositionRepository : BaseRepository<Composition>, ICompositionRepository
    {
        public CompositionRepository(MusicLibraryContext context) : base(context)
        {
        }

        public override IQueryable<Composition> GetAll()
        {
            return base.GetAll().Include(x => x.Albums.Select(album => album.Performer));
        }

        public override bool UpdateEntity(int id, Composition newValue)
        {
            var composition = GetEntity(id);
            if (composition == null)
            {
                return false;
            }
            composition.Albums = newValue.Albums;
            composition.Genre = newValue.Genre;
            composition.Name = newValue.Name;
            composition.Text = newValue.Text;
            SaveChanges();
            return true;
        }
    }
}
