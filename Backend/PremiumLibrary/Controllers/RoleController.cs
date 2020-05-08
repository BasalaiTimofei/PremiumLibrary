using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiumLibrary.Models.ViewModels.Role;
using PremiumLibrary.Services;

namespace PremiumLibrary.Controllers
{
    [Route("api/role")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] RoleListingModel model)
        {
            try
            {
                var result = await _roleService.Create(model.Name);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost]
        [Route("invite")]
        public async Task<ActionResult> Invite([FromBody] InviteOrLeaveUserFromRole model)
        {
            try
            {
                await _roleService.InviteUser(model.UserId, model.RoleId);
                return Ok("Invite");
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost]
        [Route("leave")]
        public async Task<ActionResult> Leave([FromBody] InviteOrLeaveUserFromRole model)
        {
            try
            {
                await _roleService.LeaveUser(model.UserId, model.RoleId);
                return Ok("Leave");
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("roles")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _roleService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}