namespace CarReservation.NET6.Models
{
    /// <summary>
    /// Vehizle reservation object
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Start date of reservation
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End Date of reservation
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
