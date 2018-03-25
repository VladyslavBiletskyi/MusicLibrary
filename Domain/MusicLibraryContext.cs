using System.Data.Entity;
using Domain.Entities;

namespace Domain
{
    internal class MusicLibraryContext : DbContext
    {
        public MusicLibraryContext() : base("MusicLibraryDb")
        {            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("Albums");
            modelBuilder.Entity<Composition>().ToTable("Compositions");
            modelBuilder.Entity<Performer>().ToTable("Performers");
            modelBuilder.Entity<Genre>().ToTable("Genres");
        }

        public System.Data.Entity.DbSet<Domain.Entities.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<Domain.Entities.Performer> Performers { get; set; }

        public System.Data.Entity.DbSet<Domain.Entities.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<Domain.Entities.Composition> Compositions { get; set; }
    }
}
