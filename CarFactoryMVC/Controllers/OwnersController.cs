
using CarFactoryMVC.Entities;
using CarFactoryMVC.Models;
using CarFactoryMVC.Services_BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CarFactoryMVC.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnersService ownersService;
        private readonly ICarsService carsService;

        public OwnersController(IOwnersService ownersService,ICarsService carsService)
        {
            this.ownersService = ownersService;
            this.carsService = carsService;
        }

        // GET: Owners
        public IActionResult Index()
        {
            return View(ownersService.GetOwners());
        }

        // GET: Owners/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = ownersService.GetById(id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                ownersService.AddOwner(owner);
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        [HttpGet]
        public IActionResult BuyCar()
        {
            ViewData["OwnerId"] = new SelectList(ownersService.GetOwners(), "Id", "Name");
            ViewData["CarId"] = new SelectList(carsService.GetAll(),"Id","VIN");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuyCar(BuyCarInput buyCarInput)
        {
            var result = ownersService.BuyCar(buyCarInput);
            if (result.Contains("Successfull"))
            {
                TempData["Buy"] = result;
                return RedirectToAction(nameof(Index),"Cars");
            }
            ModelState.AddModelError("", result);
            ViewData["OwnerId"] = new SelectList(ownersService.GetOwners(), "Id", "Name");
            ViewData["CarId"] = new SelectList(carsService.GetAll(), "Id", "VIN");
            return View();
        }
    }
}
