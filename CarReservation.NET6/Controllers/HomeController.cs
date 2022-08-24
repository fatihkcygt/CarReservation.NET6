using CarReservation.NET6.InMemorySingleton;
using CarReservation.NET6.Interfaces;
using CarReservation.NET6.Models;
using CarReservation.NET6.Utils.RequestHandler;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarReservation.NET6.Controllers
{
    /// <summary>
    /// Car Reservation Operations
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor of HomeController
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Index View
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get All cars
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/home/GetAllCars")]
        [ProducesResponseType(typeof(VehicleStorage), 200)]
        public IActionResult GetAllCars()
        {
            return Json(new { items = VehicleStorage.Instance });
        }

        /// <summary>
        /// Get All upcoming reservations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/home/GetUpcomingReservations")]
        [ProducesResponseType(typeof(VehicleStorage), 200)]
        public IActionResult GetUpcomingReservations()
        {
            var UpcomingReservations = VehicleStorage.Instance.Where(x => x.reservations.Any(y => y.StartDate > DateTime.Now));
            return Json(new { items = UpcomingReservations });
        }

        /// <summary>
        /// Insert Dummy Data
        /// </summary>
        /// <returns>All Vehicles</returns>
        [HttpPost]
        [Route("/home/InsertDummyData")]
        [ProducesResponseType(typeof(VehicleStorage), 200)]
        public IActionResult InsertDummyData()
        {
            Car opel = new Car("Opel", "Insignia");
            Car bmw = new Car("BMW", "5.20");
            Car audi = new Car("Audi", "A8");
            return Json(new {status = "All dummy cars inserted.", items = VehicleStorage.Instance });
        }

        /// <summary>
        /// Add new car
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/home/AddCar")]
        [ProducesResponseType(typeof(IVehicle), 200)]
        public IActionResult AddCar([FromBody] InsertCar Request)
        {
            Car AddedCar = new Car(Request.Make, Request.Model);
            return Json(new { status = "Car added.", item = AddedCar });
        }

        /// <summary>
        /// Delete Car
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/home/Delete")]
        [ProducesResponseType(typeof(IVehicle), 200)]
        public IActionResult Delete([FromBody] DeleteCar Request)
        {
            var DeletedCar = VehicleStorage.Instance.Where(x => x.Id == Request.Id).FirstOrDefault();
            VehicleStorage.Instance.Remove(DeletedCar); 
            return Json(new { status = "Car deleted.", item = DeletedCar });
        }

        /// <summary>
        /// Update Car
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("/home/Update")]
        [ProducesResponseType(typeof(IVehicle), 200)]
        public IActionResult Update([FromBody] UpdateCar Request)
        {
            var UpdatedCar = VehicleStorage.Instance.Where(x => x.Id == Request.Id).FirstOrDefault();
            UpdatedCar.Make = Request.Make;
            UpdatedCar.Model = Request.Model;
            return Json(new { status = "Car updated.", item = UpdatedCar });
        }

        /// <summary>
        /// Set reservation by id
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/home/SetReservation")]
        [ProducesResponseType(typeof(IVehicle), 200)]
        public IActionResult SetReservation([FromBody] ReservationRequest Request)
        {
            var car = VehicleStorage.Instance.Where(x => x.Id == Request.Id).FirstOrDefault();
            DateTime StartDate = DateTime.ParseExact(Request.StartDate, "dd/MM/yyyy HH:mm", null);
            DateTime EndDate = DateTime.ParseExact(Request.EndDate, "dd/MM/yyyy HH:mm", null);
            car.setReservation(StartDate, EndDate);
            return Json(new { status = "Reservation added.", item = car });
        }

        /// <summary>
        /// Privacy
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}