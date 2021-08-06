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
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
