namespace CarReservation.NET6.Exceptions
{
    /// <summary>
    /// Reservation 24 Hour Exception
    /// </summary>
    [Serializable]
    public class Hour24Exception : Exception
    {
        /// <summary>
        /// Contructor of Hour24Exception
        /// </summary>
        public Hour24Exception()
            : base("The reservation can be taken up to 24 hours ahead.")
        {

        }
    }

    /// <summary>
    /// Duration Exception
    /// </summary>
    [Serializable]
    public class DurationException : Exception
    {
        /// <summary>
        ///  Contructor of DurationException
        /// </summary>
        public DurationException()
            : base("The duration can take up to 2 hours.")
        {

        }
    }
}
