using System.Web.Mvc;
using Domain.Interfaces;
using Domain.Repositories;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace Domain
{
    public class DomainNinjectModule : NinjectModule
    {
        public void Init()
        {
            var kernel = new StandardKernel(this);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
        public override void Load()
        {
            Bind<MusicLibraryContext>().ToSelf().InSingletonScope();
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            Bind<IAlbumRepository>().To<AlbumRepository>();
            Bind<IGenreRepository>().To<GenreRepository>();
            Bind<ICompositionRepository>().To<CompositionRepository>();
            Bind<IPerformerRepository>().To<PerformerRepository>();
        }
    }
}