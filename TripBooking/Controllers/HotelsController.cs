using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripBooking.DAL;
using TripBooking.Models;
using TripBooking.Services;

namespace TripBooking.Controllers
{
    public class HotelsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;

        public HotelsController(AppDbContext context,IHotelService hotelService, IRoomService roomService)
        {
            _context = context;
            _hotelService = hotelService;
            _roomService = roomService;
        }
        public IActionResult Details(int id, DateTime checkIn, DateTime checkOut)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }

            var availableRooms = _roomService.GetAvailableRooms(id, checkIn, checkOut);

            var viewModel = new HotelInfoViewModel
            {
                Hotel = hotel,
                AvailableRooms = availableRooms,
                CheckIn = checkIn,
                CheckOut = checkOut
            };

            return View(viewModel);
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            if (hotels == null)
            {
                return NotFound();
            }
            return View(hotels);
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,Name,City,Country")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelId,Name,City,Country")] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.HotelId == id);
        }

        public IActionResult HotelInfo(int id, DateTime checkIn, DateTime checkOut)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }

            var availableRooms = _roomService.GetAvailableRooms(id, checkIn, checkOut);

            var viewModel = new HotelInfoViewModel
            {
                Hotel = hotel,
                AvailableRooms = availableRooms,
                CheckIn = checkIn,
                CheckOut = checkOut
            };

            return View(viewModel);
        }

    }
}
