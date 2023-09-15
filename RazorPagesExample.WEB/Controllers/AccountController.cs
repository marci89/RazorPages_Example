using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using RazorPagesExample.Business.Models;
using RazorPagesExample.Business.Services;
using RazorPagesExample.Localization;
using System.Security.Claims;

namespace RazorPagesExample.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AccountController(UserService service, IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _localizer = localizer;
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
            ModelState.AddModelError("Password", _localizer["LoginFailed"]);

            return View(model);
        }

        /// <summary>
        /// Return the registration view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View(new RegistrationViewModel());
        }

        /// <summary>
        /// Create user
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Registration", model);

            var success = await _service.Create(model);
            if (success)
                return RedirectWithSuccess("Index", "Home", null, _localizer["SaveSuccess"]);

            return ReloadWithError("Registration", model, _localizer["SaveFailed"]);

        }

        /// <summary>
        /// Return the edit user view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var request = new UserUpdateViewModel();
            var id = GetUserId();
            var user = await _service.ReadUserById(id);
            if (user != null)
            {
                request = new UserUpdateViewModel
                {
                    Id = user.Id,
                    Username = user?.Name,
                    Email = user?.Email,
                    DateOfBirth = user.DateOfBirth,
                };
            }

            return View(request);
        }

        /// <summary>
        /// Update user
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View("EditProfile", model);

            var success = await _service.Update(model);

            if (success)
                return RedirectWithSuccess("Index", "Home", null, _localizer["EditSuccess"]);

            return ReloadWithError("EditProfile", model, _localizer["EditFailed"]);

        }


        /// <summary>
        /// logout the user and navigates to the main page.
        /// After an unsuccessful logout due to [Authorize], the default login page will appear
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
