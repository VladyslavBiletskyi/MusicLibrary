using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace Domain.Entities
{
    public class Composition : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Text { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
