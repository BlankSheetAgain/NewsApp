using Application.Commands;
using Application.Commands.Comments;
using Application.Commands.Comments.Create;
using Application.Commands.Comments.Delete;
using Application.Commands.Comments.Update;
using Application.Queries.Comments;

using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentQueryResult>>> GetAllCommentsForNews(Guid newsId)
        {
            var comments = await Sender.Send(new GetAllCommentsQuery { NewsId = newsId });

            return Ok(comments);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CommentQueryResult>> GetCommentForNews(Guid id, Guid newsId)
        {
            var comment = await Sender.Send(new GetCommentByIdQuery
            {
                NewsId = newsId,
                Id = id
            });

            return Ok(comment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(Guid newsId, [FromBody] CreateCommentCommand createCommentCommand)
        {
            createCommentCommand.NewsId = newsId;

            var result = await Sender.Send(createCommentCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateComment(Guid id, Guid newsId, [FromBody] UpdateCommentCommand updateCommentCommand)
        {
            updateCommentCommand.Id = id;

            updateCommentCommand.NewsId = newsId;

            var result = await Sender.Send(updateCommentCommand);

            return Ok(result);
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
