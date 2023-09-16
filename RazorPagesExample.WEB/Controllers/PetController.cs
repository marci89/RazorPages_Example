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
        public async Task<IActionResult> Index()
        {
            var id = GetUserId();
            var pets = await _service.ListPet(id);
            return View(pets);
        }

        /// <summary>
        /// Return the create view for modal
        /// </summary>
        [HttpGet]
        public IActionResult CreatePet()
        {
            //Return partial view because it will be a modal content.
            return PartialView(new PetCreateViewModel());
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
        /// Return the edit pet view for modal
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditPet(long id)
        {
            var request = new PetUpdateViewModel();

            var pet = await _service.ReadPetById(id);
            if (pet != null)
            {
                request = new PetUpdateViewModel
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Age = pet.Age
                };
            }

            //Return partial view because it will be a modal content.
            return PartialView(request);
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
