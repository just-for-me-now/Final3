using Final3.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final3.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/")]
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
        public IActionResult VehiclesByOwner(long id)
        {
            Owner vehiclesByOwner = context.Owners
                .Include(owner => owner.Vehicles)
                .Single<Owner>(elem => elem.Id == id);
            
            return View("VehiclesByOwner",vehiclesByOwner);
        }

        [HttpGet("/vehicles/{id}/claims")]
        public IActionResult ClaimsByVehicle(long id)
        {
            Vehicle claimsByVehicle = context.Vehicles
                .Include(vehicle => vehicle.Claims)
                .Single<Vehicle>(elem => elem.Id == id);

            return View("ClaimsByVehicle", claimsByVehicle);
        }
    }
}
