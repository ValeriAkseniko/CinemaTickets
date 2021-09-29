using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Ticket
{
    public class TicketViewDTO
    {
        public Guid Id { get; set; }

        public Guid FilmId { get; set; }
        public string FilmTitle { get; set; }

        public Guid PlaceId { get; set; }
        public int PlaceNumber { get; set; }

        public Guid RowId { get; set; }
        public int RowNumber { get; set; }

        public Guid HallId { get; set; }
        public string HallTitle { get; set; }

        public Guid StatusId { get; set; }
        public string StatusTitle { get; set; }

        public Guid? CashierId { get; set; }
        public string CashierName { get; set; }

        public TypeOfCalculation? TypeOfCalculation { get; set; }
        public DateTime? DateOfSale { get; set; }
        public DateTime Start { get; set; }
        public decimal Price { get; set; }
    }
}
