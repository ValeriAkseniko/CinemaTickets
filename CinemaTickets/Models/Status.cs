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
        public string Name { get; set; }
        public Status()
        {

        }
        public Status(string name,Guid? id=null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid();
            }
            else
            {
                this.Id = id.Value;
            }
            this.Name = name;
        }
    }
}
