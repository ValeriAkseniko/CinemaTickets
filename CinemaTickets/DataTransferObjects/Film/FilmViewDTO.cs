using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Film
{
    public class FilmViewDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public Guid AgeRestrictionId { get; set; }
        public string AgeRestrictionTitle { get; set; }

        public Guid GenreId { get; set; }
        public string GenreTitle { get; set; }
    }
}
