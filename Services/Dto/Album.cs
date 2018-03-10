using System;
using System.Collections.Generic;

namespace Services.Dto
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }

        public Performer Performer { get; set; }
    }
}
