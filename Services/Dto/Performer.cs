using System;
using System.Collections.Generic;

namespace Services.Dto
{
    public class Performer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
