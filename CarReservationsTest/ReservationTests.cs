using CarReservation.NET6.Exceptions;
using CarReservation.NET6.InMemorySingleton;
using CarReservation.NET6.Interfaces;
using CarReservation.NET6.Models;

namespace CarReservationsTest
{
    public class ReservationTests
    {
        [Fact]
        public void ReserveUnder24HourTest()
        {
            Car testCar = new Car("Opel", "Meriva");
            Assert.Throws<Hour24Exception>(
                () => testCar.setReservation(DateTime.Now, DateTime.Now.AddHours(5))
        
                );
        }

        [Fact]
        public void UpTo2HourTest()
        {
            Car testCar = new Car("Opel", "Meriva");
            Assert.Throws<DurationException>(
                () => testCar.setReservation(DateTime.Now.AddHours(25), DateTime.Now.AddHours(28))

                );
        }

        [Fact]
        public void SuccessReservation()
        {
            Car testCar = new Car("Opel", "Meriva");
            testCar.setReservation(DateTime.Now.AddHours(25), DateTime.Now.AddHours(26));
            Assert.True(testCar.reservations.Count == 1); 
        }
    }
}