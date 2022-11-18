using Final3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final2.Controllers
{
    [Route("/")]
    public class AppController : Controller
    {
        FinalContext context;

        public AppController(FinalContext context)
        {
            this.context = context;
        }

        [HttpGet("/owners")]
        public IActionResult Owners()
        {
            
            ICollection<Owner> owners = context.Owners.OrderBy(x => x.LastName).ToList();
            
            return View("Owners", owners);
        }

        [HttpGet("/vehicles")]
        public IActionResult Vehicles()
        {
            ICollection<Vehicle> vehicles = context.Vehicles.OrderBy(x => x.Vin).ToList();

            return View("Vehicles", vehicles);
        }

        [HttpGet("/claims")]
        public IActionResult Claims()
        {
            ICollection<Claim> claims = context.Claims.OrderBy(x => x.Id).ToList();
            return View("Claims",claims);
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
