using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    public class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TitleOfTicket { get; set; } = null!;
        public string DateArrive { get; set; } = null!;
        public string DateDeparture { get; set; } = null!;
        public string CityArrive { get; set; } = null!;
        public string CityDeparture { get; set; } = null!;
        public string Dinner { get; set; } = null!;
        public string TypeOfPlan { get; set; } = null!;
    }
}
