using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Album : BaseEntity
    {
        public string Image { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }

        public Performer Performer { get; set; }
    }
}
