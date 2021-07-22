using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets
{
    class TicketContext : DbContext
    {
        public TicketContext()
            : base("TicketDB")
        { }

        public DbSet<AgeRestriction> AgeRestrictions { get; set; }
    }
}
