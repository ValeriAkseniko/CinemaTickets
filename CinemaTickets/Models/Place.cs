using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Place
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public Place()
        {

        }
        public Place(int number,int capacity,Guid? id=null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid();
            }
            else
            {
                this.Id = id.Value;
            }
            this.Number = number;
            this.Capacity = capacity;
        }
    }
}
