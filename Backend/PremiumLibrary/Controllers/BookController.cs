using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels;
using PremiumLibrary.Models.ViewModels.Book;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _bookService;
                var result = await service.GetAll(userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byCount/{count}")]
        public async Task<ActionResult> GetByCount(string count)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _bookService;
                var result = await service.GetAll(userId);
                return Ok(result.Take(Convert.ToInt32(count)));
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
                using var service = _bookService;
                var result = await service.GetById(id, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byAuthor/{id}")]
        public async Task<ActionResult> GetByAuthor(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _bookService;
                var result = await service.GetByAuthor(id, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byGenre/{id}")]
        public async Task<ActionResult> GetByGenre(string id)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _bookService;
                var result = await service.GetByGenre(id, userId);
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
                using var service = _bookService;
                var result = await service.GetByLikes(userId);
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
                using var service = _bookService;
                var result = await service.GetByName(name, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byProcess/{process}")]
        public async Task<ActionResult> GetByProcess(int process)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _bookService;
                var result = await service.GetByProcess(process, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("assessment")]
        public async Task<ActionResult> AddAssessment([FromBody] AddAssessment model)
        {
            string userId = "anyId";
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];

            try
            {
                using var service = _bookService;
                await service.AddAssessment(model.BookId, userId, model.Assessment);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("process")]
        public async Task<ActionResult> AddOrChangeProcess([FromBody] AddProcess model)
        {
            string userId;
            if (Request.Cookies.ContainsKey("id"))
            {
                userId = Request.Cookies["id"];
            }
            else
            {
                return BadRequest("Error");
            }

            try
            {
                using var service = _bookService;
                await service.AddOrUpdateProcess(model.BookId, userId, model.Process);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] BookCreateModel model)
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
                using var service = _bookService;
                var result = await service.AddBook(model);
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
                using var service = _bookService;
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
