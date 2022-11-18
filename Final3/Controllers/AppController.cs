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

        [HttpPost("/owners")]
        public IActionResult AddOwner()
        {
            string? firstName = Request.Form["firstName"];
            string? lastName = Request.Form["lastName"];
            string? driverLicense = Request.Form["driverLicense"];

            if (firstName == null || lastName == null || driverLicense == null)
            {
                return RedirectToAction("Owners");
            }
            Owner owner = new Owner
            {
                FirstName = firstName,
                LastName = lastName,
                DriverLicense = driverLicense,
            };

            context.Owners.Add(owner);
            context.SaveChanges();

            return RedirectToAction("VehiclesByOwner", new { id = owner.Id });
        }

        [HttpPost("/owners/{id}/vehicles")]
        public IActionResult AddVehicle(long id)
        {
            Owner? owner = context.Owners.Find(id);
            if (owner == null)
            {
                return RedirectToAction("Owners");
            }

            string? brand = Request.Form["brand"];
            string? vin = Request.Form["vin"];
            string? color = Request.Form["color"];
            int? year = Int32.Parse(Request.Form["year"]);

            if (brand == null || vin == null || color == null || year == null)
            {
                return RedirectToAction("Vehicles");
            }
            Vehicle vehicle = new Vehicle
            {
                Brand = brand,
                Vin = vin,
                Color = color,
                Year = year,
                OwnerId = owner.Id,
            };

            context.Vehicles.Add(vehicle);
            context.SaveChanges();

            return RedirectToAction("ClaimsByVehicle", new { id = vehicle.Id });
        }

        [HttpPost("/vehicles/{id}/claims")]
        public IActionResult AddClaims(long id)
        {
            Vehicle? vehicle = context.Vehicles.Find(id);
            if (vehicle == null)
            {
                return RedirectToAction("Vehicles");
            }

            string? description = Request.Form["description"];
            string? status = Request.Form["status"];
            DateTime? date = DateTime.Parse(Request.Form["date"]);

            if (description == null || status == null || date == null)
            {
                return RedirectToAction("Vehicles");
            }
            Claim claim = new Claim
            {
                Description = description,
                Status = status,
                Date = date,
                VehicleId = id,
            };
            vehicle.Claims?.Add(claim);
            context.Claims.Add(claim);
            context.SaveChanges();

            return RedirectToAction("ClaimsByVehicle", new { id = vehicle.Id });
        }

        [HttpPut("/owners/{id}")]
        public IActionResult UpdateOwner(long id)
        {

            Owner? owner = context.Owners.Find(id);
            if (owner == null)
            {
                return RedirectToAction("Owners");
            }

            string? firstName = Request.Form["firstName"];
            string? lastName = Request.Form["lastName"];
            string? driverLicense = Request.Form["driverLicense"];

            if (firstName == null || lastName == null || driverLicense == null)
            {
                return RedirectToAction("VehiclesByOwner", new { id = id });
            }

            owner.FirstName = firstName;
            owner.LastName = lastName;
            owner.DriverLicense = driverLicense;

            context.Owners.Update(owner);
            context.SaveChanges();

            return RedirectToAction("VehiclesByOwner", new { id = id });
        }

        [HttpPut("/vehicles/{id}")]
        public IActionResult UpdateVehicle(long id)
        {
            Vehicle? vehicle = context.Vehicles.Find(id);
            if (vehicle == null)
            {
                return RedirectToAction("Vehicles");
            }

            string? brand = Request.Form["brand"];
            string? vin = Request.Form["vin"];
            string? color = Request.Form["color"];
            int? year = Int32.Parse(Request.Form["year"]);

            if (brand == null || vin == null || color == null || year == null)
            {
                return RedirectToAction("ClaimsByVehicle", new { id = id });
            }
            vehicle.Brand = brand;
            vehicle.Vin = vin;
            vehicle.Color = color;
            vehicle.Year = year;

            context.Vehicles.Update(vehicle);
            context.SaveChanges();

            return RedirectToAction("ClaimsByVehicle", new { id = vehicle.Id });
        }

        [HttpPut("/claims/{id}")]
        public IActionResult UpdateClaims(long id)
        {
            Claim? claim = context.Claims.Find(id);
            if (claim == null)
            {
                return RedirectToAction("Claims");
            }

            string? description = Request.Form["description"];
            string? status = Request.Form["status"];
            DateTime? date = DateTime.Parse(Request.Form["date"]);

            if (description == null || status == null || date == null)
            {
                return RedirectToAction("Vehicles");
            }

            claim.Description = description;
            claim.Status = status;
            claim.Date = date;

            context.Claims.Update(claim);
            context.SaveChanges();

            return RedirectToAction("ClaimsByVehicle", new { id = id });
        }
    }
}
