using CommentStore.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elementic.Microservice.Comments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentServices _commentServices;
        public CommentsController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            return Ok(_commentServices.GetComments());
        }

        [HttpGet("{id}", Name="GetComment")]
        public IActionResult GetComment(string id)
        {
            return Ok(_commentServices.GetComment(id));
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _commentServices.AddComent(comment);
            return CreatedAtRoute("GetComment", new { id = comment.Id }, comment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(string id)
        {
            _commentServices.DeleteComment(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            return Ok(_commentServices.UpdateComment(comment));
        }
    }
}
