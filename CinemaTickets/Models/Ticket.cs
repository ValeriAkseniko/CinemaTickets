using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public Guid FilmId { get; set; }
        public Film Film { get; set; }

        public Guid PlaceId { get; set; }
        public Place Place { get; set; }

        public Guid StatusId { get; set; }
        public Status Status { get; set; }

        public Guid? CashierId { get; set; }
        public Cashier Cashier { get; set; }

        public TypeOfCalculation? TypeOfCalculation { get; set; }
        public DateTime? DateOfSale { get; set; }
        public DateTime Start { get; set; }
        public decimal Price { get; set; }        
    }
}
