using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace Domain.Entities
{
    public class Album : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }

        [Required]
        public Performer Performer { get; set; }
    }
}
