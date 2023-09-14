using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RazorPagesExample.WEB.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        /// <summary>
        /// return home page
        /// </summary>
        protected virtual IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// return user id from ClaimTypes
        /// </summary>
        protected virtual long GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
