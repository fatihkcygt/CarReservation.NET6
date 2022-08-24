namespace CarReservation.NET6.Utils.RequestHandler
{
    /// <summary>
    /// Request model for update car
    /// </summary>
    public class UpdateCar
    {
        /// <summary>
        /// Updated Car Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Updated Car Make
        /// </summary>
        public string Make { get; set; }
        /// <summary>
        /// Updated Car Model
        /// </summary>
        public string Model { get; set; }

    }
}
