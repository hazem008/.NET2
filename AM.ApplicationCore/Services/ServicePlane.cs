using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;


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

        public bool IsAvailablePlane(Flight f, int n)
        {
            //Méthode 1
            //var capacity = f.plane.Capacity;
            //var tickets = f.tickets.Count();
            //return capacity-tickets> n;

            ////Méthode 2
            //var plane = GetAll().Where(p=> p.Flights.Contains(f)==true).FirstOrDefault();
            //equivalent
            var plane = Get(p => p.Flights.Contains(f)==true);
            var capacity = plane.Capacity;
            var flight = plane.Flights.Single(j => j.FlightId == f.FlightId);
            var tickets = flight.tickets.Count();
            return capacity - tickets > n;
        }

        public void DeletePlane()
        {
            //1er méthode
            //    var l= GetAll().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);
            //    foreach (var p in l)
            //    {
            //        Delete(p);
            //    }
            //    Commit(); // commit ta3mil sauvgarder fil BD
            
            //2éme méthode
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3600);
            Commit();
        }
    }
}
