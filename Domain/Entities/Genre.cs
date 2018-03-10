using Microsoft.Build.Framework;

namespace Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
