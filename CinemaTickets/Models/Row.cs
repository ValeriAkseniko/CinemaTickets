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
        public Row()
        {
            this.Places = new List<Place>();
        }
        public Row(int number,List<Place> Places,Guid? id= null)
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
            this.Places = Places;
        }
    }
}
