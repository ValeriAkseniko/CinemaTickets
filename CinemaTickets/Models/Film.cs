using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public AgeRestriction AgeRestrictions { get; set; }
        public Genre Genre { get; set; }
        public Film()
        {

        }
        public Film(string title,int duration,string description,AgeRestriction ageRestrictions,Genre genre,Guid? id = null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid();
            }
            else
            {
                this.Id = id.Value;
            }
            this.Title = title;
            this.Duration = duration;
            this.Description = description;
            this.AgeRestrictions = ageRestrictions;
            this.Genre = genre;
        }
    }
}
