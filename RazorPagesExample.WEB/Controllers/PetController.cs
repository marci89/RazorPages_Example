using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using RazorPagesExample.Business.Models;
using RazorPagesExample.Business.Services;
using RazorPagesExample.Localization;

namespace RazorPagesExample.WEB.Controllers
{


    public class PetController : BaseController
    {
        private readonly PetService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public PetController(PetService service, IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _localizer = localizer;
        }


        /// <summary>
        /// Return Pet index view
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return the create view
        /// </summary>
        [HttpGet]
        public IActionResult CreatePet()
        {
            return View(new PetCreateViewModel());
        }

        /// <summary>
        /// Create pet
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePet(PetCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View("CreatePet", model);

            var id = GetUserId();
            model.UserId = id;

            var success = await _service.Create(model);
            if (success)
                return RedirectWithSuccess("Index", "Pet", null, _localizer["SaveSuccess"]);

            return ReloadWithError("CreatePet", model, _localizer["SaveFailed"]);

        }

        /// <summary>
        /// Return the edit pet view
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditPet()
        {
            var request = new PetUpdateViewModel();

            var id = GetUserId();
            var pet = await _service.ReadPetById(id);
            if (pet != null)
            {
                request = new PetUpdateViewModel
                {
                    Name = pet.Name,
                    Age = pet.Age
                };
            }

            return View(request);
        }

        /// <summary>
        /// Update pet
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdatePet(PetUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View("UpdatePet", model);

            var success = await _service.Update(model);

            if (success)
                return RedirectWithSuccess("Index", "Pet", null, _localizer["EditSuccess"]);

            return ReloadWithError("UpdatePet", model, _localizer["EditFailed"]);

        }


        /// <summary>
        /// Delete pet. The sweetalert isConfirmed part call this from Pet.js
        /// </summary>
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.Delete(id);
            return new JsonResult(new { success = result });
        }
    }
}
