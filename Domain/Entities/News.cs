using Domain.Common;
using Domain.Identity;

namespace Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
