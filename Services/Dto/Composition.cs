using System.Collections.Generic;

namespace Services.Dto
{
    public class Composition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public Genre Genre { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
