using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return plane.Flights.SelectMany(p => p.tickets)
                 .Select(t => t.passenger)
                 .Distinct()
                 .ToList();
        }
        public IList<Flight> GetFlights(int n)
        {
            //    return GetAll().OrderBy(p => p.PlaneId)
            //        .TakeLast(n).SelectMany(p=> p.Flights)
            //        .OrderBy(p=> p.FlightDate)
            //        .ToList();
            //}
            return GetAll()
                .OrderByDescending(p => p.PlaneId)
                      .Take(n).SelectMany(p => p.Flights)
                      .OrderBy(p => p.FlightDate)
                      .ToList();

        }
    }
}
