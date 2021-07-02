using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class AgeRestrictions
    {
        Guid Id { get; set; }
        int MinAge { get; set; }
        string Title { get; set; }
        string Description { get; set; }
    }
}
