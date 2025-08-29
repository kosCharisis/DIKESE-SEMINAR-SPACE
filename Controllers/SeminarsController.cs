using DIKESE.Data;
using DIKESE.Data.Services;
using DIKESE.Data.Static;
using DIKESE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DIKESE.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class SeminarsController : Controller
    {
        public readonly ISeminarsService _service;

        public SeminarsController(ISeminarsService service)
        {
            _service = service;
        }

        [AllowAnonymous]

        public async Task<ActionResult> Index()
        {
            var allSeminars = await _service.GetAllAsync(n => n.Room);
            return View(allSeminars);
        }

        [AllowAnonymous]

        public async Task<IActionResult> Filter(string searchString)
        {
            var allSeminars = await _service.GetAllAsync(n => n.Room);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allSeminars.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allSeminars);
        }



        //GET: Seminars/Details/1

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var seminarDetail = await _service.GetSeminarByIdAsync(id);
            return View(seminarDetail);
        }

        //GET: Seminars/Create
        public async Task<IActionResult> Create()
        {
            var seminarDropdownsData = await _service.GetNewSeminarDropdownsValues();

            ViewBag.Rooms = new SelectList(seminarDropdownsData.Rooms, "Id", "Name");
            ViewBag.Sponsors = new SelectList(seminarDropdownsData.Sponsors, "Id", "FullName");
            ViewBag.Speakers = new SelectList(seminarDropdownsData.Speakers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewSeminarVM seminar)
        {
            if (!ModelState.IsValid)
            {
                var seminarDropdownsData = await _service.GetNewSeminarDropdownsValues();

                ViewBag.Rooms = new SelectList(seminarDropdownsData.Rooms, "Id", "Name");
                ViewBag.Sponsors = new SelectList(seminarDropdownsData.Sponsors, "Id", "FullName");
                ViewBag.Speakers = new SelectList(seminarDropdownsData.Speakers, "Id", "FullName");

                return View(seminar);
            }

            await _service.AddNewSeminarAsync(seminar);
            return RedirectToAction(nameof(Index));
        }

        //GET: Seminars/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var seminarDetails = await _service.GetSeminarByIdAsync(id);
            if (seminarDetails == null) return View("NotFound");

            var response = new NewSeminarVM()
            {
                Id = seminarDetails.Id,
                Name = seminarDetails.Name,
                Description = seminarDetails.Description,
                Price = seminarDetails.Price,
                StartDate = seminarDetails.StartDate,
                EndDate = seminarDetails.EndDate,
                ImageURL = seminarDetails.ImageURL,
                SeminarCategory = seminarDetails.SeminarCategory,
                RoomId = seminarDetails.RoomId,
                SponsorId = seminarDetails.SponsorId,
                SpeakerIds = seminarDetails.Speakers_Seminars.Select(n => n.SpeakerId).ToList(),
            };

            var seminarDropdownsData = await _service.GetNewSeminarDropdownsValues();
            ViewBag.Rooms = new SelectList(seminarDropdownsData.Rooms, "Id", "Name");
            ViewBag.Sponsors = new SelectList(seminarDropdownsData.Sponsors, "Id", "FullName");
            ViewBag.Speakers = new SelectList(seminarDropdownsData.Speakers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewSeminarVM seminar)
        {
            if (id != seminar.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var seminarDropdownsData = await _service.GetNewSeminarDropdownsValues();

                ViewBag.Rooms = new SelectList(seminarDropdownsData.Rooms, "Id", "Name");
                ViewBag.Sponsors = new SelectList(seminarDropdownsData.Sponsors, "Id", "FullName");
                ViewBag.Speakers = new SelectList(seminarDropdownsData.Speakers, "Id", "FullName");

                return View(seminar);
            }

            await _service.UpdateSeminarAsync(seminar);
            return RedirectToAction(nameof(Index));
        }

        //Get: Speakers/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var seminarDetails = await _service.GetSeminarByIdAsync(id);

            if (seminarDetails == null)
            {
                return View("NotFound");
            }
            return View(seminarDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminarDetails = await _service.GetSeminarByIdAsync(id);

            if (seminarDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
