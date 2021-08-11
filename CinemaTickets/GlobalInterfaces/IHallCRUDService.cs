using CinemaTickets.DataTransferObjects.Hall;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IHallCRUDService
    {
        bool Create(HallCreateDTO hall);

        Hall Get(Guid id);

        List<Hall> List();

        bool Update(Hall hall, Guid id);

        bool Delete(Guid id);
    }
}
