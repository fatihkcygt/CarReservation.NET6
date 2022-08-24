using System.Security.Principal;

namespace CarReservation.NET6.Utils.RequestHandler
{
    /// <summary>
    /// Request Model for Delete Car
    /// </summary>
    public class DeleteCar
    {
        /// <summary>
        /// Deleted Car Id
        /// </summary>
        public string Id { get; set; }
    }
}
