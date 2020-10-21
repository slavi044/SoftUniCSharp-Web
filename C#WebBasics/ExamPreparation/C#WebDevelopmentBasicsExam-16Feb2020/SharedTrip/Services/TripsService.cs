using System;
using System.Globalization;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AddTripInputModel trip)
        {
            Trip dbTrip = new Trip
            {
                DepartureTime = DateTime.ParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = trip.Description,
                EndPoint = trip.EndPoint,
                ImagePath = trip.ImagePath,
                Seats = (byte)trip.Seats,
                StartingPoint = trip.StartPoint,
            };

            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }
    }
}
