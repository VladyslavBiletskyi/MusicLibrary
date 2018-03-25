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
            modelBuilder.Entity<Composition>().ToTable("Composition");
            modelBuilder.Entity<Performer>().ToTable("Performer");
            modelBuilder.Entity<Genre>().ToTable("Genre");
        }

        public System.Data.Entity.DbSet<Domain.Entities.Genre> Genres { get; set; }
    }
}
