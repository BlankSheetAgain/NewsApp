﻿using Application.Commands.Newss;
using Application.Commands.Newss.Create;
using Application.Commands.Newss.Delete;
using Application.DTOs;
using Application.Queries.Newss;

using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDTO>>> GetAllNews()
        {
            var news = await Sender.Send(new GetAllNewsQuery());

            return Ok(news);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<NewsDTO>> GetNewsById(Guid id)
        {
            var news = await Sender.Send(new GetNewsByIdQuery { Id = id });

            return Ok(news);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNews([FromBody] CreateNewsCommand createNewsCommand)
        {
            var result = await Sender.Send(createNewsCommand);

            return Ok(result);
        }

        [HttpDelete("id:guid")]
        public async Task<ActionResult> DeleteNews(Guid id)
        {
            var result = await Sender.Send(new DeleteNewsCommand { Id = id });

            return Ok(result);
        }

        //[HttpPut("{id:guid")]
        //public async Task<ActionResult>
    }
}
