using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RazorPagesExample.Business.Models;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RazorPagesExample.WEB.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        /// <summary>
        /// Redirects to the recommended page and displays a successful save message
        /// </summary>
        protected virtual ActionResult RedirectWithSuccess(string actionName, string controllerName = null, object routeValues = null, string message = null)
        {
            TempData[ViewDataKeys.SuccessMessage] = message;
            return RedirectToAction(actionName, controllerName, routeValues);
        }

        /// <summary>
        /// Returns the specified view and displays the successful save message
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected virtual ActionResult Success([CallerMemberName] string viewName = null, object model = null, string message = null)
        {
            TempData[ViewDataKeys.SuccessMessage] = message;
            return View(viewName, model);
        }

        /// <summary>
        /// Returns the specified view and displays the error message
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected virtual ActionResult ReloadWithError([CallerMemberName] string viewName = null, object model = null, string messageTitle = null, string messageText = null)
        {
            TempData[ViewDataKeys.ErrorMessage] = messageTitle;
            TempData[ViewDataKeys.ErrorMessageText] = messageText;
            return View(viewName, model);
        }

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
