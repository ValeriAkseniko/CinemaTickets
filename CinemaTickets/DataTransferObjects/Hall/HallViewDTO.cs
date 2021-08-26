using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataTransferObjects.Hall
{
    public class HallViewDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Guid> RowId { get; set; }
    }
}
