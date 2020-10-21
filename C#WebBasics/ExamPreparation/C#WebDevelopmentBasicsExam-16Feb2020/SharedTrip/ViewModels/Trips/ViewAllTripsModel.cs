using System.Collections.Generic;

namespace SharedTrip.ViewModels.Trips
{
    public class ViewAllTripsModel
    {
        public IEnumerable<TripViewModel> Trips { get; set; }
    }
}
