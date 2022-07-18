using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Application.Commands.Comments.Update
{
    public class UpdateCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Guid NewsId { get; set; }
    }
}
