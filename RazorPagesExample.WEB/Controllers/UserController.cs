using Microsoft.AspNetCore.Mvc;
using RazorPagesExample.Business.Services;

namespace RazorPagesExample.WEB.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Return Users index view
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var id = GetUserId();
            var users = await _service.ListUser(id);
            return View(users);
        }

        /// <summary>
        /// Delete user. The sweetalert isConfirmed part call this from user.js
        /// </summary>
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.Delete(id);
            return new JsonResult(new { success = result });
        }
    }
}
