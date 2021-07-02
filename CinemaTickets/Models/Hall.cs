using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Hall
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Row CountRows { get; set; }
        public Hall()
        {

        }
        public Hall(string titel,Row countRows)
        {
            this.Id = Guid.NewGuid();
            this.Title = titel;
            this.CountRows = countRows;
        }
    }
}
