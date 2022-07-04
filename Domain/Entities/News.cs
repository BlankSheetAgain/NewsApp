using Domain.Common;

namespace Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
