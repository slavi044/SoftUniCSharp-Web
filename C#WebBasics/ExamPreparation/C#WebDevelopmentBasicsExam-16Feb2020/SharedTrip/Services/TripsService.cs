using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        public IEnumerable<TripViewModel> GetAll()
        {
            return this.db
                .Trips
                .Select(x => new TripViewModel
                {
                    DepartureTime = x.DepartureTime,
                    StartPoint = x.StartingPoint,
                    EndPoint = x.EndPoint,
                    Seats = x.Seats,
                    UsedSeats = x.UserTrips.Count(),
                    Id = x.Id,
                })
                .ToList();
        }
    }
}
