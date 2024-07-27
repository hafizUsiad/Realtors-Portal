using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Real_Estate.Data;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public PropertiesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var properties = _context.Properties.ToList();
            if (properties != null)
            {
                return View(properties);

            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var property = _context.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(propertyaddmodel property)
        {
            var idd = Guid.NewGuid;
            var pro = new Propertyy
            {

                Title = property.Title,
                Description = property.Description,
                Price = property.Price,
                Address = property.Address,
                PostedDate = DateTime.Now,
                ImageUrl = "Nothing",
            };
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Website\\img");
            string uniqueFileName = pro.Title.ToString() + ".png";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await property.Image.CopyToAsync(stream);
                }
                _context.Properties.Add(pro);
                await _context.SaveChangesAsync();
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(property);
        }

        public IActionResult Edit(int id)
        {
            var property = _context.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }

        [HttpPost]
        public IActionResult Edit(Propertyy property)
        {
            if (ModelState.IsValid)
            {
                _context.Properties.Update(property);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        public IActionResult Delete(int id)
        {
            var property = _context.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }
            _context.Properties.Remove(property);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    
    }
}