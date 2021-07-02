using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Cashier
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Cashier()
        {

        }
        public Cashier(string fullName)
        {
            this.Id = Guid.NewGuid();
            this.FullName = fullName;
        }
    }
}
