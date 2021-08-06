using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class AgeRestriction
    {
        public Guid Id { get; set; }
        public int MinAge { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
