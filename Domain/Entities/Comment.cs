using Domain.Common;
using Domain.Identity;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public virtual News? News { get; set; }

        public ApplicationUser User { get; set; }
    }
}
