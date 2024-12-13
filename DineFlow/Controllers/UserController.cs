using DineFlow.DTOs;
using DineFlow.Interfaces;
using DineFlow.Services;
using Microsoft.AspNetCore.Mvc;

namespace DineFlow.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManagementService _userService;

        public UserController(IUserManagementService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(userDto.Email, userDto.Password, userDto.RoleId, userDto.LocationId);
                return Redirect("Index");
            }

            return View(userDto);
        }
    }
}
