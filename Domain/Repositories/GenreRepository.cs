using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repositories
{
    internal class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MusicLibraryContext context) : base(context)
        {
        }

        public override bool UpdateEntity(int id, Genre newValue)
        {
            var genre = GetEntity(id);
            if (genre == null)
            {
                return false;
            }
            genre.Description = newValue.Description;
            genre.Name = newValue.Name;
            SaveChanges();
            return true;
        }
    }
}
