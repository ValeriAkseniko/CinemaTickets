using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Place
{
    public class PlaceCreateDTO
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }

        public Guid RowId { get; set; }
    }
}
