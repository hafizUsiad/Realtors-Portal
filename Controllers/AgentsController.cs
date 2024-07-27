using Microsoft.AspNetCore.Mvc;

using Real_Estate.Data;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
    public class AgentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var agents = _context.Agents.ToList();
            return View(agents);
        }

        public IActionResult Details(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Agents.Add(agent);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        public IActionResult Edit(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        [HttpPost]
        public IActionResult Edit(Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Agents.Update(agent);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        public IActionResult Delete(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}