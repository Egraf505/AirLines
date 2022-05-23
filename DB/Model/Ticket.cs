using System;
using System.Collections.Generic;

namespace DB
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public decimal Price { get; set; }
        public int IdAirLines { get; set; }

        public virtual AirLine IdAirLinesNavigation { get; set; } = null!;
        public virtual User? IdUserNavigation { get; set; }
    }
}
