using DIKESE.Data;
using DIKESE.Data.Services;
using DIKESE.Data.Static;
using DIKESE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIKESE.Controllers
{

    [Authorize(Roles = UserRoles.Admin)]
    public class SponsorsController : Controller
    {
        public readonly ISponsorsService _service;

        public SponsorsController(ISponsorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allSponsors = await _service.GetAllAsync();
            return View(allSponsors);
        }

        //GET: Sponsors/details/1

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var sponsorDetails = await _service.GetByIdAsync(id);
            if (sponsorDetails == null) return View("NotFound");
            return View(sponsorDetails);
        }

        //GET: Sponsors/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Sponsor sponsor)
        {
            if (!ModelState.IsValid) return View(sponsor);

            await _service.AddAsync(sponsor);
            return RedirectToAction(nameof(Index));
        }

        //GET: Sponsors/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var sponsorDetails = await _service.GetByIdAsync(id);
            if (sponsorDetails == null) return View("NotFound");
            return View(sponsorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Sponsor sponsor)
        {
            if (!ModelState.IsValid) return View(sponsor);

            if (id == sponsor.Id)
            {
                await _service.UpdateAsync(id, sponsor);
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        //GET: Sponsors/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var sponsorDetails = await _service.GetByIdAsync(id);
            if (sponsorDetails == null) return View("NotFound");
            return View(sponsorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsorDetails = await _service.GetByIdAsync(id);
            if (sponsorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }        


    }
}
