using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            AgeRestriction age = new AgeRestriction
            {
                Id = Guid.NewGuid(),
                MinAge = 18,
                Title = "18+",
                Description = "Кровь,кишки,матюки и голые сиськи"
            };
        }
    }
}
