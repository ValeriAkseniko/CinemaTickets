using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Rows
{
    public class RowViewDTO
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<Guid> PlaceId { get; set; }
        public Guid HallId { get; set; }
        public string HallTitle { get; set; }
    }
}
