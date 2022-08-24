using CarReservation.NET6.Interfaces;

namespace CarReservation.NET6.InMemorySingleton
{
    /// <summary>
    /// Singleton Vehizle List
    /// </summary>
    public class VehicleStorage : List<IVehicle>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly static VehicleStorage instance = new VehicleStorage();
        /// <summary>
        /// Cponstructor of  Storage
        /// </summary>
        private VehicleStorage() { }

        /// <summary>
        /// Get exist instance
        /// </summary>
        public static VehicleStorage Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
