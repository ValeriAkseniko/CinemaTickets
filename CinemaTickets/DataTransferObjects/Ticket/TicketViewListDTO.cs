using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Ticket
{
    public class TicketViewListDTO
    {
        public Guid Id { get; set; }
        public string FilmTitle { get; set; }
        public int PlaceNumber { get; set; }
        public int RowNumber { get; set; }
        public string HallTitle { get; set; }
        public DateTime Start { get; set; }
        public decimal Price { get; set; }
    }
}
