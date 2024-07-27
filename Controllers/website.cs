using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Data;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
    public class website : Controller
    {
        private readonly ApplicationDbContext _context;

        public website(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult property()
        {
            var properties = _context.Properties.Take(12).ToList();
            return View(properties);
        }
        public IActionResult contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> contact([Bind("id,Name,Email,Subject,Message")] contact user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public IActionResult usercontact()
        {
            var contact = _context.contact.ToList();
            return View(contact);
        }

        [HttpGet]
        public IActionResult about()
        {
            return View();
        }
    }
}
