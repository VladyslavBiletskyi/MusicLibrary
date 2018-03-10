using System.Data.Entity;

namespace Domain
{
    internal class MusicLibraryContext : DbContext
    {
        public MusicLibraryContext() : base("MusicLibraryDb")
        {            
        }
    }
}
