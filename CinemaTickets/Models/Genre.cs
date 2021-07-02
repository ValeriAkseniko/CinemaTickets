using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre()
        {

        }
        public Genre(string title,string description,Guid? id =null)
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
            this.Description = description;
        }
    }
}
