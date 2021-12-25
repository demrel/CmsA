using CmsA.Data.Data;
using CmsA.Web.Models.Accaount;
using Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Threading.Tasks;


namespace CmsA.Controllers;

public class AccaountController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public AccaountController(SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {

        _signInManager = signInManager;
        _roleManager = roleManager;
        _userManager = userManager;
    }






    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        return View(new LoginModel { ReturnUrl = returnUrl });
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SeedUsers(int id)
    {
        if (id != 743116) return NotFound();
        ApplicationDbInitializer.SeedUsers(_userManager, _roleManager);
        return Ok("seeded");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {

        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName.Trim(), model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {

                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login və ya şifrə düzgün deyil");
            }
        }
        return View(model);
    }


    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/home/index");
    }



}


