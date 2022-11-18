using Microsoft.AspNetCore.Mvc;

namespace Final2.Controllers
{
    [Route("/")]
    public class AppController : Controller
    {
        [HttpGet("/owners")]
        public IActionResult Owners()
        {
            return View();
        }

        [HttpGet("/vehicles")]
        public IActionResult Vehicles()
        {
            return View();
        }

        [HttpGet("/claims")]
        public IActionResult Claims()
        {
            return View();
        }

        [HttpGet("/owners/{id}/vehicles")]
        public IActionResult VehiclesByOwner()
        {
            return View();
        }

        [HttpGet("/vehicles/{vehicleId}/claims")]
        public IActionResult ClaimsByVehicle()
        {
            return View();
        }
    }
}
