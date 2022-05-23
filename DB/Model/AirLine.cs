using System;
using System.Collections.Generic;

namespace DB
{
    public partial class AirLine
    {
        public AirLine()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? IdCompany { get; set; }
        public int? IdPlanes { get; set; }
        public int? CityDeparture { get; set; }
        public DateTime? DatetimeDeparture { get; set; }
        public int? CityArrival { get; set; }
        public DateTime? DatetimeArrival { get; set; }

        public virtual City? CityArrivalNavigation { get; set; }
        public virtual City? CityDepartureNavigation { get; set; }
        public virtual AirCompany? IdCompanyNavigation { get; set; }
        public virtual Plan? IdPlanesNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
