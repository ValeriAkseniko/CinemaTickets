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

        List<HallViewListDTO> List();

        HallViewDTO Get(Guid id);

        bool Update(HallUpdateDTO hall, Guid id);

        bool Delete(Guid id);
    }
}
