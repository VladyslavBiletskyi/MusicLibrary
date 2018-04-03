using System.Collections.Generic;
using Domain.Entities;

namespace MusicLibrary.Models
{
    public class PlaylistData
    {
        public IEnumerable<Performer> SelectedPerformers { get; set; }
        public IEnumerable<Genre> SelectedGenres { get; set; }
    }
}