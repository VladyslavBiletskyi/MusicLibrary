using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Performer : BaseEntity
    {
        public DateTime DateOfBirth { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
