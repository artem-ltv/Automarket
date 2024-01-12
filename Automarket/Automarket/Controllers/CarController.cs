using Automarket.Service.Interfaces;
using Automarket.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _carService.GetAllCars();
            return View(response.Data);
        }
    }
}
