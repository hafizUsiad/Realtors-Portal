using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Data;
using Real_Estate.Models;
using RealEstate.Migrations;

namespace Real_Estate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var properties = _context.Properties.Take(6).ToList();
            return View(properties);
        }

        public IActionResult Admin_panel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> login(LoginViewModel loginViewModel)
        {

            var userr = await _context.user.FirstOrDefaultAsync(u => u.email == loginViewModel.email && u.password == loginViewModel.password);
            HttpContext.Session.SetString("username", userr.name);
            HttpContext.Session.SetString("userid", userr.id.ToString());
            HttpContext.Session.SetString("userrole", userr.roleid.ToString());

            if (userr.roleid == "1")
            {
                return RedirectToAction("Admin_panel");
            }
            else
            {
                return RedirectToAction("Admin_panel");
            }



        }

        public IActionResult register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> register([Bind("id,name,email,password,phone,roleid")] user user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(login));
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("userrole");

            return RedirectToAction("Login", "Home");
        }

    }
}