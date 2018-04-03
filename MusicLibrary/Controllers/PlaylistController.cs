using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Interfaces;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPerformerRepository performerRepository;
        private readonly IGenreRepository genreRepository;
        private readonly ICompositionRepository compositionRepository;

        public PlaylistController(IPerformerRepository performerRepository, IGenreRepository genreRepository, ICompositionRepository compositionRepository)
        {
            this.performerRepository = performerRepository;
            this.genreRepository = genreRepository;
            this.compositionRepository = compositionRepository;
        }

        [Route("")]
        public ActionResult Select()
        {
            var playlistData = new PlaylistData
            {
                SelectedGenres = genreRepository.GetAll().ToList(),
                SelectedPerformers = performerRepository.GetAll().ToList(),
            };
            return View(playlistData);
        }

        [HttpPost]
        public ActionResult Generate(FormCollection collection)
        {
            var performerIds = collection.GetValues("performers")?.Select(int.Parse) ?? new List<int>();
            var genreIds = collection.GetValues("genres")?.Select(int.Parse) ?? new List<int>();

            var compositionsOfSelectedPerformers = performerRepository.GetAll()
                .Where(performer => performerIds.Contains(performer.Id)).SelectMany(performer => performer.Albums)
                .SelectMany(album => album.Compositions).ToList();

            var compositionOfGenres = compositionRepository.GetAll().Where(composition => genreIds.Contains(composition.Genre.Id)).ToList();

            var allCompositions = compositionsOfSelectedPerformers.Union(compositionOfGenres).Distinct().GroupBy(composition => composition.Albums.First().Performer);

            return View("Playlist", allCompositions);
        }
    }
}