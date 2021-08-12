using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Ticket
{
    public class TicketUpdateDTO
    {
        public Guid FilmId { get; set; }
        public Guid PlaceId { get; set; }
        public Guid StatusId { get; set; }
        public Guid CashierId { get; set; }
        public DateTime DateOfSale { get; set; }
        public DateTime Start { get; set; }
        public decimal Price { get; set; }
    }
}
