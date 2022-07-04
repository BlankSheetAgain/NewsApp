using Application.Commands;
using Application.DTOs;
using Application.Queries;

using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllCommentsForNews(Guid newsId)
        {
            var comments = await Sender.Send(new GetAllCommentsQuery {NewsId = newsId});

            return Ok(comments);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CommentDTO>> GetCommentForNews(Guid id, Guid newsId)
        {
            var comment = await Sender.Send(new GetCommentByIdQuery
            {
                NewsId = newsId,
                Id = id
            });

            return Ok(comment);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCommentForNews(Guid id, Guid newsId)
        {
            var result = await Sender.Send(new DeleteCommentCommand 
            {
            Id = id,
            NewsId = newsId
            });

            return Ok(result);
        }
    }
}
