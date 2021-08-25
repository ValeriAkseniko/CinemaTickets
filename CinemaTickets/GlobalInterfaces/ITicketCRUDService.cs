using CinemaTickets.DataTransferObjects.Ticket;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface ITicketCRUDService
    {
        bool Create(TicketCreateDTO ticket);

        TicketViewDTO Get(Guid id);

        List<TicketViewListDTO> List();

        bool Update(TicketUpdateDTO ticket, Guid id);

        bool Delete(Guid id);
    }
}
