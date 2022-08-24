namespace CarReservation.NET6.Models
{
    /// <summary>
    /// Error View Model
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request ID
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Show request ID
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}