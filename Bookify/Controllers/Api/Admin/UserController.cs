using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Bookify.Dtos;
using Bookify.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bookify.Controllers.Api.Admin;

public class UserController : BaseApiController
{
    private readonly UserManager<User> _userManager;
    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userManager.Users.Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                DisplayName = user.DisplayName,
                Roles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult()
            }
        );
        return Ok(users);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded) return BadRequest();
        return Ok();

    }
}