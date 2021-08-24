using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Film
{
    public class FilmViewListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
    }
}
