using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/autofill")]
    public class AutoFillController : Controller
    {
        private readonly IAutoFillService _autoFillService;

        public AutoFillController(IAutoFillService autoFillService)
        {
            _autoFillService = autoFillService;
        }

        [HttpGet]
        [Route("roles")]
        public async Task<ActionResult> CreateRoles()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateRoles();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult> CreateUsers()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateUsers();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("genres")]
        public async Task<ActionResult> CreateGenres()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateGenres();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("authors")]
        public async Task<ActionResult> CreateAuthors()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateAuthors();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("books")]
        public async Task<ActionResult> CreateBooks()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateBooks();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("dependency/author")]
        public async Task<ActionResult> CreateDependencyAuthorBook()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateDependencyAuthorBook();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("dependency/genre")]
        public async Task<ActionResult> CreateDependencyGenreBook()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateDependencyGenreBook();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("like/book")]
        public async Task<ActionResult> CreateBookLike()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateBookLike();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("like/author")]
        public async Task<ActionResult> CreateAuthorLike()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateAuthorLike();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("like/genre")]
        public async Task<ActionResult> CreateGenreLike()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateGenreLike();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("comment/book")]
        public async Task<ActionResult> CreateCommentBook()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateCommentBook();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("comment/author")]
        public async Task<ActionResult> CreateCommentAuthor()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateCommentAuthor();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("assessment")]
        public async Task<ActionResult> CreateAssessment()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateAssessment();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("process")]
        public async Task<ActionResult> CreateProcess()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateProcess();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

        [HttpGet]
        [Route("admin")]
        public async Task<ActionResult> CreateAdmin()
        {
            try
            {
                using var autoFillService = _autoFillService;
                await autoFillService.CreateAdmin();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error \n{e}");
            }
        }

    }
}