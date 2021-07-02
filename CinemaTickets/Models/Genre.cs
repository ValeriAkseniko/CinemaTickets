using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Genre
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre()
        {

        }
        public Genre(string title,string description)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
        }
    }
}
