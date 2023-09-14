using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RazorPagesExample.Business.Models;
using RazorPagesExample.Business.Services;
using System.Security.Claims;

namespace RazorPagesExample.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserService _service;

        public AccountController(UserService service)
        {
            _service = service;
        }


        /// <summary>
        /// return the login view.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        /// <summary>
        /// Login
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Login", model);

            var authResult = await _service.Login(model);

            if (authResult != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, authResult.Id.ToString()),
                    new Claim(ClaimTypes.Name, authResult.Name)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

                return RedirectToHome();
            }
            ModelState.AddModelError("Password", " Login failed.");

            return View(model);
        }


        /// <summary>
        /// logout the user and navigates to the main page.
        /// After an unsuccessful logout due to [Authorize], the default login page will appear
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToHome();
        }
    }
}
