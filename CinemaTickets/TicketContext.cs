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
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
