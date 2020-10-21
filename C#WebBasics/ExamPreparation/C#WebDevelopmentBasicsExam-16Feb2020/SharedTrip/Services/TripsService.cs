﻿using System;
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

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);

            if (userInTrip)
            {
                return false;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();

            return true;
        }


        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db
                .Trips
                .Where(x => x.Id == tripId)
                .Select(x => new { x.Seats, TakenSeats = x.UserTrips.Count() })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;

            return availableSeats > 0;
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

        public TripDetailsViewModel GetDetails(string id)
        {
            return this.db
                .Trips
                .Where(x => x.Id == id)
                .Select(x => new TripDetailsViewModel
                {
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    StartPoint = x.StartingPoint,
                    UsedSeats = x.UserTrips.Count()
                })
                .FirstOrDefault();
        }
    }
}
