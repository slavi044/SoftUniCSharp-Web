﻿using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            ViewAllTripsModel trips = new ViewAllTripsModel() { Trips = this.tripsService.GetAll().ToList() };
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            var trip = this.tripsService.GetDetails(tripId);

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (this.tripsService.HasAvailableSeats(tripId))
            {
                return this.Error("No seats available");
            }

            string userId = this.User;
            this.tripsService.AddUserToTrip(userId, tripId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (string.IsNullOrEmpty(input.StartPoint))
            {
                this.Error("Invalid start point");
            }

            if (string.IsNullOrEmpty(input.EndPoint))
            {
                this.Error("Invalid end point");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                this.Error("Seats should be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length > 80 )
            {
                this.Error("Invalid description");
            }

            if (!DateTime.TryParseExact(input.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                return this.Error("Invalide deaprture time.");
            }

            tripsService.Create(input);

            return this.Redirect("/Trips/All");
        }
    }
}
