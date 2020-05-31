using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/like")]
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("book/{id}")]
        public async Task<ActionResult> AddBookLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.AddBookLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("author/{id}")]
        public async Task<ActionResult> AddAuthorLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.AddAuthorLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("genre/{id}")]
        public async Task<ActionResult> AddGenreLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.AddGenreLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("book/comment/{id}")]
        public async Task<ActionResult> AddBookCommentLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.AddBookCommentLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("author/comment/{id}")]
        public async Task<ActionResult> AddAuthorCommentLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.AddAuthorCommentLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("book/{id}")]
        public async Task<ActionResult> DeleteBookLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.DeleteBookLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("author/{id}")]
        public async Task<ActionResult> DeleteAuthorLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.DeleteAuthorLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("genre/{id}")]
        public async Task<ActionResult> DeleteGenreLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.DeleteGenreLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("book/comment/{id}")]
        public async Task<ActionResult> DeleteBookCommentLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.DeleteBookCommentLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("author/comment/{id}")]
        public async Task<ActionResult> DeleteAuthorCommentLike(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _likeService;
                await service.DeleteAuthorCommentLike(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}