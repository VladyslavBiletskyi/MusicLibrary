using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repositories
{
    internal class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(MusicLibraryContext context) : base(context)
        {
        }

        public override IQueryable<Album> GetAll()
        {
            return base.GetAll().Include(x => x.Compositions).Include(x => x.Performer);
        }

        public override bool UpdateEntity(int id, Album newValue)
        {
            var album = GetEntity(id);
            if (album == null)
            {
                return false;
            }
            album.Compositions = newValue.Compositions;
            album.DateOfCreation = newValue.DateOfCreation;
            album.Name = newValue.Name;
            album.Image = newValue.Image;
            SaveChanges();
            return true;
        }

        public override bool RemoveEntity(Album entity)
        {
            return entity == null;
        }

        public void RemoveAlbumWithCompositions(Album entity)
        {
            var compositions = entity.Compositions.Where(composition =>
                composition.Albums.Count == 1 && composition.Albums.First() == entity);
            RemoveOtherEntities(compositions);
            base.RemoveEntity(entity);
            SaveChanges();
        }
    }
}
