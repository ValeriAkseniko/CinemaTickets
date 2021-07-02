using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Cashier
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Cashier()
        {

        }
        public Cashier(string fullName,Guid? id =null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid();
            }
            else
            {
                this.Id = id.Value;
            }
            this.FullName = fullName;
        }
    }
}
