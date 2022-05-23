using System;
using System.Collections.Generic;

namespace DB
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Middlename { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
