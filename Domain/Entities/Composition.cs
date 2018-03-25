using System.Collections.Generic;

namespace Domain.Entities
{
    public class Composition : BaseEntity
    {
        public string Text { get; set; }

        public Genre Genre { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
