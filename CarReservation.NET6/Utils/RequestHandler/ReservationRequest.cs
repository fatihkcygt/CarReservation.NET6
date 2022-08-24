namespace CarReservation.NET6.Utils.RequestHandler
{
    /// <summary>
    /// Request model for reservations
    /// </summary>
    public class ReservationRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Start Date of Reservation
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// End Date of reservation
        /// </summary>
        public string EndDate { get; set; }

    }
}
