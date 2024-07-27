using Microsoft.AspNetCore.Mvc;

using Real_Estate.Data;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
    public class PrivateSellersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivateSellersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var privateSellers = _context.PrivateSellers.ToList();
            return View(privateSellers);
        }

        public IActionResult Details(int id)
        {
            var privateSeller = _context.PrivateSellers.Find(id);
            if (privateSeller == null)
            {
                return NotFound();
            }
            return View(privateSeller);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                _context.PrivateSellers.Add(privateSeller);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(privateSeller);
        }

        public IActionResult Edit(int id)
        {
            var privateSeller = _context.PrivateSellers.Find(id);
            if (privateSeller == null)
            {
                return NotFound();
            }
            return View(privateSeller);
        }

        [HttpPost]
        public IActionResult Edit(PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                _context.PrivateSellers.Update(privateSeller);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(privateSeller);
        }

        public IActionResult Delete(int id)
        {
            var privateSeller = _context.PrivateSellers.Find(id);
            if (privateSeller == null)
            {
                return NotFound();
            }
            return View(privateSeller);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var privateSeller = _context.PrivateSellers.Find(id);
            if (privateSeller != null)
            {
                _context.PrivateSellers.Remove(privateSeller);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
