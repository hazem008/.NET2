using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }

        public int FlightId { get; set;}
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimationDuration { get; set; }
        //[ForeignKey(nameof(PlaneFK))] 2eme méthode
        // ? properité nullable 
        public Plane? plane { get; set; } // propriété de navigation
        [ForeignKey("plane")] //1er méthode 
        public int? PlaneFK { get; set; }
        public ICollection<Ticket> tickets { get; set; }
        public override string ToString()
        {
            return FlightId + " " + Destination + " " + Departure + " " + FlightDate + " " + EffectiveArrival + " " + EstimationDuration;
        }
    }
}
