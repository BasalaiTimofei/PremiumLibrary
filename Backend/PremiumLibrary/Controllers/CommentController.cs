using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels.Comment;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("book/{id}")]
        public async Task<ActionResult> GetByBook(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _commentService;
                var result = await service.GetBookComments(id, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("author/{id}")]
        public async Task<ActionResult> GetByAuthor(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _commentService;
                var result = await service.GetAuthorComments(id, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("book")]
        public async Task<ActionResult> AddByBook([FromBody] BookCommentCreateModel model)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _commentService;
                await service.AddBookComment(model, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("author")]
        public async Task<ActionResult> AddByAuthor([FromBody] AuthorCommentCreateModel model)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _commentService;
                await service.AddAuthorComment(model, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("book/{id}")]
        public async Task<ActionResult> DeleteByBook(string id)
        {
            if (Request.Cookies.ContainsKey("role"))
            {
                var role = Request.Cookies["admin"];
                if (role != "admin") return BadRequest("Error");
            }
            else
            {
                return BadRequest("Error");
            }

            try
            {
                using var service = _commentService;
                await service.DeleteBookComment(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("author/{id}")]
        public async Task<ActionResult> DeleteByAuthor(string id)
        {
            if (Request.Cookies.ContainsKey("role"))
            {
                var role = Request.Cookies["admin"];
                if (role != "admin") return BadRequest("Error");
            }
            else
            {
                return BadRequest("Error");
            }

            try
            {
                using var service = _commentService;
                await service.DeleteAuthorComment(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}