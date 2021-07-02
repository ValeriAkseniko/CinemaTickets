using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Place
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public Place()
        {

        }
        public Place(int number,int capacity)
        {
            this.Id = Guid.NewGuid();
            this.Number = number;
            this.Capacity = capacity;
        }
    }
}
