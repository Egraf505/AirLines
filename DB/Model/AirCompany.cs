using System;
using System.Collections.Generic;

namespace DB
{
    public partial class AirCompany
    {
        public AirCompany()
        {
            AirLines = new HashSet<AirLine>();
            Plans = new HashSet<Plan>();
        }

        public int Id { get; set; }
        public string Tittle { get; set; } = null!;

        public virtual ICollection<AirLine> AirLines { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
