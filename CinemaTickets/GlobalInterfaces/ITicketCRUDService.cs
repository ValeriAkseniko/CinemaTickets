using CinemaTickets.DataTransferObjects.Ticket;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface ITicketCRUDService
    {
        bool Create(TicketCreateDTO ticket);

        TicketViewDTO Get(Guid id);

        List<TicketViewListDTO> List();

        bool Update(TicketUpdateDTO ticket, Guid id);

        bool Delete(Guid id);

        List<TicketViewListDTO> ListPagination(int page, int pageSize);
    }
}
