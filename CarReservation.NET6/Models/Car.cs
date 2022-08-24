using CarReservation.NET6.Interfaces;
using CarReservation.NET6.Exceptions;
using CarReservation.NET6.InMemorySingleton;

namespace CarReservation.NET6.Models
{
    /// <summary>
    /// Car class
    /// </summary>
    public class Car : IVehicle
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Make
        /// </summary>
        public string Make { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Reservation list for vehicle
        /// </summary>
        public List<Reservation> reservations { get; set; }  

        /// <summary>
        /// Car constructor
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        public Car(string make, string model)
        {
            Id = getId();
            Make = make;
            Model = model;
            reservations = new List<Reservation>();
            VehicleStorage.Instance.Add(this);
        }   

        /// <summary>
        /// Get new id
        /// </summary>
        /// <returns></returns>
        public string getId()
        {
            if (VehicleStorage.Instance.Count == 0)
            {
                return "C1";
            }
            else
            {
                var LastVehicleID = Convert.ToInt16(VehicleStorage.Instance.Last().Id.Replace("C", ""));
                return "C" + (LastVehicleID + 1).ToString();
            }
        }
        /// <summary>
        /// Delete car
        /// </summary>
        /// <param name="vehicles"></param>
        public void delete(VehicleStorage vehicles)
        {
            var car = VehicleStorage.Instance.Where(x => x.Id == this.Id).FirstOrDefault();
            VehicleStorage.Instance.Remove(car);
        }

        /// <summary>
        /// Update Car
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="vehicles"></param>
        /// <returns></returns>
        public IVehicle update(string make, string model, VehicleStorage vehicles)
        {
            var car = VehicleStorage.Instance.Where(x => x.Id == this.Id).FirstOrDefault();
            car.Make = make;
            car.Model = model;
            return car;
        }

        /// <summary>
        /// Set Reservation
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        /// <exception cref="Hour24Exception"></exception>
        /// <exception cref="DurationException"></exception>
        public IVehicle setReservation(DateTime startDate, DateTime endDate)
        {
            if (startDate < DateTime.UtcNow.AddHours(24))
            {
                throw new Hour24Exception();
            }
            if ((endDate - startDate).Hours > 2){
                throw new DurationException();
            }

            Reservation reservation = new Reservation();
            reservation.StartDate = startDate;
            reservation.EndDate = endDate;
            this.reservations.Add(reservation);
            return this;
        }
    }
}
