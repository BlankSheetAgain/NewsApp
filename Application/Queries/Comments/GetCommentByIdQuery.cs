using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Application.Queries.Comments
{
    public class GetCommentByIdQuery : IRequest<CommentQueryResult>
    {
        public Guid Id { get; set; }

        public Guid NewsId { get; set; }
    }
}
