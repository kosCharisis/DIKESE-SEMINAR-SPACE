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
    public class RoomsController : Controller
    {
        private readonly IRoomsService _service;

        public RoomsController(IRoomsService service)
        {
            _service = service;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var allRooms = await _service.GetAllAsync();
            return View(allRooms);
        }

        //GET: Rooms/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Room room)
        {
            if (!ModelState.IsValid) return View(room);

            await _service.AddAsync(room);
            return RedirectToAction(nameof(Index));
        }

        //GET: Rooms/details/1

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var roomDetails = await _service.GetByIdAsync(id);
            if (roomDetails == null) return View("NotFound");
            return View(roomDetails);
        }

        //Get: Rooms/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var roomDetails = await _service.GetByIdAsync(id);
            if (roomDetails == null) return View("NotFound");
            return View(roomDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Room room)
        {
            if (!ModelState.IsValid) return View(room);
            await _service.UpdateAsync(id, room);
            return RedirectToAction(nameof(Index));
        }

        //Get: Roooms/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var roomDetails = await _service.GetByIdAsync(id);
            if (roomDetails == null) return View("NotFound");
            return View(roomDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var roomDetails = await _service.GetByIdAsync(id);
            if (roomDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
