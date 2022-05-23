using System;
using System.Collections.Generic;

namespace DB
{
    public partial class City
    {
        public City()
        {
            AirLineCityArrivalNavigations = new HashSet<AirLine>();
            AirLineCityDepartureNavigations = new HashSet<AirLine>();
        }

        public int Id { get; set; }
        public string Tittle { get; set; } = null!;

        public virtual ICollection<AirLine> AirLineCityArrivalNavigations { get; set; }
        public virtual ICollection<AirLine> AirLineCityDepartureNavigations { get; set; }
    }
}
