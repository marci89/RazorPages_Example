using Microsoft.AspNetCore.Mvc;

namespace RazorPagesExample.WEB.Controllers
{
    public class PetController : BaseController
    {
        /// <summary>
        /// Return Pet index view
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
