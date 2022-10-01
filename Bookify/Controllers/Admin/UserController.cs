using System.Security.Cryptography;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Bookify.Models.Identity;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Admin;

public class UserController : BaseAdminController
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserStore<User> _userStore;
    private readonly IUserEmailStore<User> _emailStore;
    private readonly UserManager<User> _userManager;
    private readonly INotyfService _notyf;



    public UserController(RoleManager<IdentityRole> roleManager, IUserStore<User> userStore,
        UserManager<User> userManager, INotyfService notyf)
    {
        _roleManager = roleManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
        _userManager = userManager;
        _notyf = notyf;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddUserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = Activator.CreateInstance<User>();
            user.DisplayName = viewModel.DisplayName;
            
            await _userStore.SetUserNameAsync(user, viewModel.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, viewModel.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, viewModel.Password);
            // Add Role
            var role = _roleManager.Roles.FirstOrDefault(r => r.Id == viewModel.RoleId);
            var roleExist = await _roleManager.RoleExistsAsync(role.Name);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            
            await _userManager.AddToRoleAsync(user, role.Name);
            
            if (result.Succeeded)
            {
                _notyf.Success("User Added Successfully");
                return RedirectToAction("Index", "User");
            }
            foreach (var error in result.Errors)
            {
                _notyf.Error("Something went wrong!");
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View();
    }

    public IActionResult Edit(string id)
    {
        var user = _userManager.FindByIdAsync(id).Result;
        if (user == null)
        {
            _notyf.Error("Wrong user id");
            return RedirectToAction("Index");
        }

        var roleName = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
        var roleId = _roleManager.Roles.FirstOrDefault(r => r.Name == roleName)?.Id;
        var viewModel = new AddUserViewModel()
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            Email = user.Email,
            RoleId = roleId,

        };
        return View(viewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit (AddUserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(viewModel.Id);
            if (user == null)
            {
                _notyf.Error("This user doesn't exists");
                return View();
            }
            user.DisplayName = viewModel.DisplayName;
            user.Email = viewModel.Email;
            // remove old role
            var oldRoleName = _userManager.GetRolesAsync(user).Result.First();
            var role = _roleManager.FindByNameAsync(oldRoleName).Result.Id;
            await _userManager.RemoveFromRoleAsync(user, role);
            // add new role
            var newRoleName = _roleManager.FindByIdAsync(viewModel.RoleId).Result.Name;
            await _userManager.AddToRoleAsync(user, newRoleName);

            if (viewModel.Password != null)
            {
                var hashedPassword = HashPassword(viewModel.Password);
                user.PasswordHash = hashedPassword;
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                _notyf.Success("User Updated Successfully");
                return RedirectToAction("Index", "User");
            }
            foreach (var error in result.Errors)
            {
                _notyf.Error("Something went wrong!");
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View();
    }
    
    private IUserEmailStore<User> GetEmailStore()
    {
        return (IUserEmailStore<User>)_userStore;
    }
    
    private string HashPassword(string password)
    {
        byte[] salt;
        byte[] buffer2;
        if (password == null)
        {
            throw new ArgumentNullException("password");
        }
        
        using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
        {
            salt = bytes.Salt;
            buffer2 = bytes.GetBytes(0x20);
        }
        byte[] dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
        return Convert.ToBase64String(dst);
    }
}