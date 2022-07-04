using Domain.Common;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual News News { get; set; }
    }
}
