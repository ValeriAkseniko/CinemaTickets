using System;
using CinemaTickets.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataTransferObjects.Status;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IStatusCRUDService
    {
        bool Create(StatusCreateDTO status);

        StatusViewDTO Get(Guid id);

        List<StatusViewListDTO> List();

        bool Update(StatusUpdateDTO status, Guid id);

        bool Delete(Guid id);
    }
}
