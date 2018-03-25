using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Performer : BaseEntity
    {
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
