using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class AgeRestrictions
    {
        public Guid Id { get; set; }
        public int MinAge { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AgeRestrictions()
        {

        }
        public AgeRestrictions(int minAge,string title,string description,Guid? id = null)
        {
            if (id==null)
            {
                this.Id = Guid.NewGuid();
            }
            else
            {
                this.Id = id.Value;
            }
            this.MinAge = minAge;
            this.Title = title;
            this.Description = description;
        }
    }
}
