using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels.Author;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _authorService;
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
                using var service = _authorService;
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
                using var service = _authorService;
                var result = await service.GetById(id, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }


        [HttpGet("byBook/{id}")]
        public async Task<ActionResult> GetByBook(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _authorService;
                var result = await service.GetByBook(id, userId);
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
                using var service = _authorService;
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
                using var service = _authorService;
                var result = await service.GetByName(name, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] AuthorCreateModel model)
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
                using var service = _authorService;
                await service.Create(model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
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
                using var service = _authorService;
                await service.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}