using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VCard.DAL;
using VCard.Models;
using VCard.Services;

namespace VCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VCardDbContext _context;
        private readonly ICreateFromJson _createFromJson;

        public HomeController(  ILogger<HomeController> logger, 
                                VCardDbContext vCardDbContext,
                                ICreateFromJson createFromJson )
        {
            _logger = logger;
            _context = vCardDbContext;
            _createFromJson = createFromJson;
        }

        public async Task<IActionResult> IndexAsync()
        {
            
            return View(_context.VCards.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> AddUser()
        {
            await _createFromJson.CreateVcardFromJson();
            return Redirect("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}