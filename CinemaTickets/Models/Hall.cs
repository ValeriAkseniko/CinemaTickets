using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Hall
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Row> Rows { get; set; }
    }
}
