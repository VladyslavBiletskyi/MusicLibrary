using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPerformerRepository : IBaseRepository<Performer>
    {
        void RemovePerformerWithChildItems(Performer performer);
    }
}