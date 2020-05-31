using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Models.ViewModels.Role;
using PremiumLibrary.Services;

namespace PremiumLibrary.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] RoleListingModel model)
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
                using var service = _roleService;
                var result = await service.Create(model.Name);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("invite")]
        public async Task<ActionResult> Invite([FromBody] InviteOrLeaveUserFromRole model)
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
                using var service = _roleService;
                await service.InviteUser(model.UserId, model.RoleId);
                return Ok("Invite");
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost("leave")]
        public async Task<ActionResult> Leave([FromBody] InviteOrLeaveUserFromRole model)
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
                using var service = _roleService;
                await service.LeaveUser(model.UserId, model.RoleId);
                return Ok("Leave");
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
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
                using var service = _roleService;
                var result = await service.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}