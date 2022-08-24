using CarReservation.NET6.InMemorySingleton;
using CarReservation.NET6.Models;

namespace CarReservation.NET6.Interfaces
{
    /// <summary>
    /// Vehicle interface
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Id
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// Make
        /// </summary>
        string Make { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        string Model { get; set; }
        /// <summary>
        /// List of reservations
        /// </summary>
        List<Reservation> reservations { get; set; }
        /// <summary>
        /// get new id
        /// </summary>
        /// <returns></returns>
        string getId();
        /// <summary>
        /// update 
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="vehicles"></param>
        /// <returns></returns>
        IVehicle update(string make, string model, VehicleStorage vehicles);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="vehicles"></param>
        void delete(VehicleStorage vehicles);
        /// <summary>
        /// Set reservation
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        IVehicle setReservation(DateTime startDate, DateTime endDate);
    }
}
