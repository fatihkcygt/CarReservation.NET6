namespace CarReservation.NET6.Utils.RequestHandler
{
    /// <summary>
    /// Request Model for insert Car
    /// </summary>
    public class InsertCar
    {
        /// <summary>
        /// Car Make
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Car Model
        /// </summary>
        public string Model { get; set; }    
    }
}
