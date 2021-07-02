using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Row
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Place CountPlace { get; set; }
        public Row()
        {

        }
        public Row(int number,Place countPlace)
        {
            this.Id = Guid.NewGuid();
            this.Number = number;
            this.CountPlace = countPlace;
        }
    }
}
