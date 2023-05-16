using DB.Model;
using System;
using System.Collections.Generic;

namespace DB
{
    public partial class Plan
    {
        public Plan()
        {
            AirLines = new HashSet<AirLine>();
        }

        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int Distance { get; set; }

        public virtual AirCompany IdCompanyNavigation { get; set; } = null!;
        public virtual ICollection<AirLine> AirLines { get; set; }
    }
}
