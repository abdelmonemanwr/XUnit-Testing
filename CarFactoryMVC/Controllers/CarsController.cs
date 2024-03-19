
using CarFactoryMVC.Entities;
using CarFactoryMVC.Services_BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarFactoryMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IOwnersService ownersService;

        public CarsController(ICarsService carsService, IOwnersService ownersService)
        {
            this.carsService = carsService;
            this.ownersService = ownersService;
        }

        // GET: Cars
        public IActionResult Index()
        {
            var factoryContext = carsService.GetAll();
            return View(factoryContext);
        }

        // GET: Cars/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carsService.GetCarById(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(ownersService.GetOwners(), "Id", "Name");
            ViewData["Type"] = new SelectList(Enum.GetNames<CarType>());
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Velocity,Price,VIN")] Car car)
        {
            if (ModelState.IsValid)
            {
                var result = carsService.AddCar(car);
                if (result)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError("", "Something went wrong");
            }
            ViewData["OwnerId"] = new SelectList(ownersService.GetOwners(), "Id", "Id", car.OwnerId);
            ViewData["Type"] = new SelectList(Enum.GetNames<CarType>());
            return View(car);
        }



        // GET: Cars/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carsService.GetCarById(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            carsService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
