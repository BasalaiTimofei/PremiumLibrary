using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Models.ViewModels.User;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Registration([FromBody] Registration model)
        {
            try
            {
                using var service = _userService;
                var result = await service.Registration(model);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

        }
        [HttpPost("authorization")]
        public async Task<ActionResult> Authorization([FromBody] Authorization model)
        {
            try
            {
                using var service = _userService;
                var result = await service.Authorization(model);
                Response.Cookies.Append("Id", result);
                Response.Cookies.Append("Role", "User");
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                using var service = _userService;
                var result = await service.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("byId")]
        public async Task<ActionResult> GetById()
        {
            string userId;
            if (Request.Cookies.ContainsKey("id"))
                userId = Request.Cookies["id"];
            else return BadRequest("Error");

            try
            {
                using var service = _userService;
                var result = await service.GetById(userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("admin")]
        public async Task<ActionResult> AdminAuthorization()
        {
            try
            {
                using var service = _userService;
                var result = await service.Authorization(new Authorization
                {
                    Password = "Password_1",
                    UserNameOrEmailAddress = "UserName_1"
                });
                Response.Cookies.Append("id", result);
                Response.Cookies.Append("role", "User");
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}