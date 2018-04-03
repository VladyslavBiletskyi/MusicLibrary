using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Album : BaseEntity
    {
        public byte[] Image { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }

        public Performer Performer { get; set; }
    }
}
