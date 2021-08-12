using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Rows
{
    public class RowUpdateDTO
    {
        public int Number { get; set; }
        public Guid HallId { get; set; }
    }
}
