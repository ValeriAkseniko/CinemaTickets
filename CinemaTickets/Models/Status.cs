using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Status
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Status()
        {

        }
        public Status(string title)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
        }
    }
}
