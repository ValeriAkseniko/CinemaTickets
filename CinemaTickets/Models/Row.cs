using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Row
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<Place> Places { get; set; }

        public Guid HallId { get; set; }
        public Hall Hall { get; set; }        
    }
}
