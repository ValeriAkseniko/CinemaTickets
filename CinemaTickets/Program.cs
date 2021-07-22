using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using CinemaTickets.Services;
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
            IAgeRestrictionsCRUDService service = new AgeRestrictionCRUDServices();
            //AgeRestriction test = new AgeRestriction
            //{
            //    Id = Guid.NewGuid(),
            //    Title = "18+",
            //    Description = "Кровь кишки",
            //    MinAge = 18
            //};
            //service.Create(test);
            AgeRestriction entity = service.Get(Guid.Parse("A2960786-0CAE-4C97-892B-9AE47B3E38DA"));
            List<AgeRestriction> ageRestrictions = service.List();
            //bool resultDeleted = service.Delete(Guid.Parse("A2960786-0CAE-4C97-892B-9AE47B3E38DA"));
            AgeRestriction test = new AgeRestriction
            {
                Id = Guid.Empty,
                Title = "18+++",
                Description = "Кровь кишкиdsdfgfghjk",
                MinAge = 19
            };

            bool resultUpdate = service.Update(test, Guid.Parse("53C48AA2-3DC9-4D1A-881B-7981A26165BD"));
            Console.ReadKey();
        }
    }
}
