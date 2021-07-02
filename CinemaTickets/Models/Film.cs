using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public AgeRestrictions ageRestrictions { get; set; }
        public Genre genre { get; set; }
        public Film()
        {

        }
        public Film(string title,double duration,string description,AgeRestrictions ageRestrictions,Genre genre)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Duration = duration;
            this.Description = description;
            this.ageRestrictions = ageRestrictions;
            this.genre = genre;
        }
    }
}
