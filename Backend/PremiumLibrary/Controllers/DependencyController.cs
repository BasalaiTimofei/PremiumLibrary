using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/dependency")]
    public class DependencyController : Controller
    {
        private readonly IDependencyService _dependencyService;

        public DependencyController(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
        }

        [HttpPost("author")]
        public async Task<ActionResult> AddDependencyAuthorBook([FromBody] DependencyAuthorBook model)
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
                using var service = _dependencyService;
                await service.AddAuthorsBook(model.BookId, model.AuthorId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error {e}");
            }
        }

        [HttpPost("delete/author")]
        public async Task<ActionResult> DeleteDependencyAuthorBook([FromBody] DependencyAuthorBook model)
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
                using var service = _dependencyService;
                await service.DeleteAuthorBook(model.BookId, model.AuthorId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error {e}");
            }
        }

        [HttpPost("genre")]
        public async Task<ActionResult> AddDependencyGenreBook([FromBody] DependencyGenreBook model)
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
                using var service = _dependencyService;
                await service.AddGenresBook(model.BookId, model.GenreId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error {e}");
            }
        }

        [HttpPost("delete/genre")]
        public async Task<ActionResult> DeleteDependencyGenreBook([FromBody] DependencyGenreBook model)
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
                using var service = _dependencyService;
                await service.DeleteGenreBook(model.BookId, model.GenreId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error {e}");
            }
        }
    }
}
