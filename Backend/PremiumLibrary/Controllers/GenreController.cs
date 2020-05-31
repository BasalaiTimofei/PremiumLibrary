using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels.Genre;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _genreService;
                var result = await service.GetAll(userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byCount/{count}")]
        public async Task<ActionResult> GetByCount(int count)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _genreService;
                var result = await service.GetAll(userId);
                return Ok(result.Take(count));
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _genreService;
                var result = await service.GetById(id, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byBook/{bookId}")]
        public async Task<ActionResult> GetByBook(string bookId)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _genreService;
                var result = await service.GetByBook(bookId, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byLike")]
        public async Task<ActionResult> GetByLike()
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _genreService;
                var result = await service.GetByLike(userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byName/{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _genreService;
                var result = await service.GetByName(name, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] GenreCreateModel model)
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
                using var service = _genreService;
                var result = await service.Create(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Error {e}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
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
                using var service = _genreService;
                await service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error {e}");
            }
        }
    }
}