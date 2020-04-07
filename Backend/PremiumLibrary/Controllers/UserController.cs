using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Models.ViewModels;
using PremiumLibrary.Services;

namespace PremiumLibrary.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<ActionResult> Registration([FromBody] RegistrationUser model)
        {
            try
            {
                var result = await _userService.Registration(model);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

        }
        [HttpPost]
        [Route("authorization")]
        public async Task<ActionResult> Authorization([FromBody] AuthorizationUser model)
        {
            try
            {
                var result = await _userService.Authorization(model);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}
