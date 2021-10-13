using System;
using System.Collections.Generic;
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

        List<StatusViewListDTO> ListPagination(int page, int pageSize);
    }
}
