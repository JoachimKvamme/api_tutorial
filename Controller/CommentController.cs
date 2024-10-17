using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_tutorial.Interfaces;
using api_tutorial.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api_tutorial.Controller
{
    [Route("api/comment")]
    [ApiController]

    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() {

            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }
    }
}