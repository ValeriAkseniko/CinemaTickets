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
            
            RowCRUDService rowCRUDService = new RowCRUDService();

            Row test = rowCRUDService.Get(Guid.Parse("DAD80150-5083-4BCA-AF78-307CE73C8A40"));
            test.HallId = Guid.Parse("1BD4C29B-CD0B-4909-ADAE-CA1B4B461E8C");
            rowCRUDService.Update(test, Guid.Parse("DAD80150-5083-4BCA-AF78-307CE73C8A40"));
            test = rowCRUDService.Get(Guid.Parse("DAD80150-5083-4BCA-AF78-307CE73C8A40"));
        }
    }
}
